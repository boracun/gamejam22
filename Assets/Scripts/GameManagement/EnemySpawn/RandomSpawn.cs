using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace GameManagement
{
    public class RandomSpawn : ISpawnBehavior
    {
        private bool eventFinalized;
        
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

                EnemySpawnManager.SpawnEventList.Remove(spawnEventKey);
            }
        }

        public static void ChooseRandomSpawnPoint(ref SpawnEvent spawnEvent)
        {
            float topBorderYPos = GameObject.Find("TopBorder").transform.position.y;
            float bottomBorderYPos = GameObject.Find("BottomBorder").transform.position.y;
            
            float leftBorderXPos = GameObject.Find("LeftBorder").transform.position.x;
            float rightBorderXPos = GameObject.Find("RightBorder").transform.position.x;
            
            System.Random random = new System.Random();
            GameObject player = GameObject.Find("Panda");
            
            Vector2 spawnPoint;
            Vector2 playerPos = player.transform.position;
            do
            {
                double randomY = (random.NextDouble() * (topBorderYPos - bottomBorderYPos) + bottomBorderYPos);
                double randomX = (random.NextDouble() * (rightBorderXPos - leftBorderXPos) + leftBorderXPos);
                spawnPoint = new Vector2((float) randomX, (float) randomY);
                
            } while (  (spawnPoint - playerPos).magnitude <= spawnEvent.spawnPlayerDistance );

            spawnEvent.spawnLocation = spawnPoint;

        }

        public static void ChooseRandomSpawnTime(ref SpawnEvent spawnEvent)
        {
            System.Random random = new System.Random();
            double randomDelay = (random.NextDouble() * (spawnEvent.spawnDelayUpperLimit - spawnEvent.spawnDelayLowerLimit) 
                                  + spawnEvent.spawnDelayLowerLimit);
            spawnEvent.spawnDelay = (float) randomDelay;
        }
    }
}