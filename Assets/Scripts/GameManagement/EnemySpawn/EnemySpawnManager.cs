using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Enemy;
using UnityEngine;

namespace GameManagement
{
    
    public class EnemySpawnManager : MonoBehaviour
    {
        public static float playerSpawnRange = 5f;
        public float spawnUpperLimit;
        public float spawnLowerLimit;

        public static Dictionary<int, SpawnEvent> SpawnEventList = new Dictionary<int, SpawnEvent>();
        public static int dicKeyIndex = 0;
        
        public void Start()
        {
            
        }

        private void Update()
        {
            foreach (KeyValuePair<int, SpawnEvent> keyValuePair in SpawnEventList)
            {
                int spawnEventKey = keyValuePair.Key;
                SpawnEventList[spawnEventKey].spawnInfo.spawnBehavior.Spawn(spawnEventKey);
            }
        }

        public static void SpawnEnemies(SpawnInfo[] spawnInfoArr)
        {
            foreach (SpawnInfo curSpawnInfo in spawnInfoArr)
            {
                SpawnEvent spawnEvent = new SpawnEvent(Vector2.zero, 0f ,curSpawnInfo, 0f, 
                    playerSpawnRange, 0f, 0f);
                SpawnEventList.Add(dicKeyIndex, spawnEvent);
                dicKeyIndex++;
            }

        }

        public static GameObject GetPrefab(EnemyType enemyType)
        {
            GameObject result = null;
            switch (enemyType)
            {
                case EnemyType.NormalEnemy:
                    result = Resources.Load("Prefabs/NormalEnemyPrefab") as GameObject;
                    break;
            }

            return result;
        }
    }
}