using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Enemy;
using UnityEngine;

namespace GameManagement
{
    
    public class EnemySpawnManager : MonoBehaviour
    {
        public static System.Random random = new System.Random();
        public static float playerSpawnRange = 2f;
        public float spawnUpperLimit;
        public float spawnLowerLimit;

        public static Dictionary<int, SpawnEvent> SpawnEventList = new Dictionary<int, SpawnEvent>();
        public static int dicKeyIndex = 0;
        
        public void Start()
        {
            
        }

        private void Update()
        {
            List<int> removedKeys = new List<int>();
            
            foreach (KeyValuePair<int, SpawnEvent> keyValuePair in SpawnEventList)
            {
                int spawnEventKey = keyValuePair.Key;
                SpawnEventList[spawnEventKey].spawnInfo.spawnBehavior.Spawn(spawnEventKey);
            }
            foreach (KeyValuePair<int, SpawnEvent> keyValuePair in SpawnEventList)
            {
                int spawnEventKey = keyValuePair.Key;
                if (SpawnEventList[spawnEventKey].spawnTimer >= SpawnEventList[spawnEventKey].spawnDelay)
                {
                    removedKeys.Add(spawnEventKey);
                }
            }

            for (int i = 0; i < removedKeys.Count; i++)
            {
                SpawnEventList.Remove(removedKeys[i]);
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
                    result = Resources.Load("Prefabs/Owlet_Monster") as GameObject;
                    break;
            }

            return result;
        }
    }
}