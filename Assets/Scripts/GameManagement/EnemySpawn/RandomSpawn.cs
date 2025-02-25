﻿using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace GameManagement
{
    public class RandomSpawn : ISpawnBehavior
    {
        private bool eventFinalized = false;
        
        public void Spawn(int spawnEventKey)
        {
            SpawnEvent spawnEvent = EnemySpawnManager.SpawnEventList[spawnEventKey];
            
            
            if (!eventFinalized)
            {
                ChooseRandomSpawnTime(ref spawnEvent);
                eventFinalized = true;
            }

            spawnEvent.spawnTimer += Time.deltaTime;
            
            if (spawnEvent.spawnTimer >= spawnEvent.spawnDelay)
            {
                ChooseRandomSpawnPoint(ref spawnEvent);
                
                GameObject enemy = GameObject.Instantiate(EnemySpawnManager.GetPrefab(spawnEvent.spawnInfo.enemyType), 
                    spawnEvent.spawnLocation, Quaternion.identity);
                
                enemy.GetComponent<EnemyProperties>().health = spawnEvent.spawnInfo.enemyHealth;
                enemy.GetComponent<EnemyMovement>().enemySpeed = spawnEvent.spawnInfo.enemySpeed;
                enemy.GetComponent<EnemyProperties>().damage = spawnEvent.spawnInfo.enemyDamage;

                EnemySpawnManager.SpawnEventList.Remove(spawnEventKey);
            }
            else //Silinebilir
            {
                EnemySpawnManager.SpawnEventList.Remove(spawnEventKey);
                EnemySpawnManager.SpawnEventList.Add(spawnEventKey, spawnEvent);
            }
        }

        public static void ChooseRandomSpawnPoint(ref SpawnEvent spawnEvent)
        {
            float topBorderYPos = GameObject.Find("TopBorder").transform.position.y - 0.5f;
            float bottomBorderYPos = GameObject.Find("BottomBorder").transform.position.y + 0.5f;
            
            float leftBorderXPos = GameObject.Find("LeftBorder").transform.position.x + 0.5f;
            float rightBorderXPos = GameObject.Find("RightBorder").transform.position.x - 1.5f;
            
            GameObject player = GameObject.Find("Panda");
            
            Vector2 spawnPoint;
            Vector2 playerPos = player.transform.position;
            do
            {
                double randomY = (EnemySpawnManager.random.NextDouble() * (topBorderYPos - bottomBorderYPos) + bottomBorderYPos);
                double randomX = (EnemySpawnManager.random.NextDouble() * (rightBorderXPos - leftBorderXPos) + leftBorderXPos);

                spawnPoint = new Vector2((float) randomX, (float) randomY);
                
            } while (  (spawnPoint - playerPos).magnitude <= spawnEvent.spawnPlayerDistance );

            spawnEvent.spawnLocation = spawnPoint;

        }

        public static void ChooseRandomSpawnTime(ref SpawnEvent spawnEvent)
        {
            double randomDelay = (EnemySpawnManager.random.NextDouble() * (spawnEvent.spawnDelayUpperLimit - spawnEvent.spawnDelayLowerLimit) 
                                  + spawnEvent.spawnDelayLowerLimit);
            spawnEvent.spawnDelay = (float) randomDelay;
        }
    }
}