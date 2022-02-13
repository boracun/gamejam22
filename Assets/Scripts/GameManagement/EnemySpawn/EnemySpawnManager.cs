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
        public float playerSpawnRange = 2f;
        public float spawnUpperLimit = 5f;
        public float spawnLowerLimit = 1f;

        public static Dictionary<int, SpawnEvent> SpawnEventList = new Dictionary<int, SpawnEvent>();
        public static int dicKeyIndex = 0;
        
        public void Start()
        {
            
        }

        private void Update()
        {
            List<int> keys = new List<int>();
            
            foreach (KeyValuePair<int, SpawnEvent> keyValuePair in SpawnEventList)
            {
                keys.Add(keyValuePair.Key);
            }
            for (int i = 0; i < keys.Count; i++)
            {
                SpawnEventList[keys[i]].spawnInfo.spawnBehavior.Spawn(keys[i]);
            }
        }

        public void SpawnEnemies(SpawnInfo[] spawnInfoArr)
        {
            foreach (SpawnInfo curSpawnInfo in spawnInfoArr)
            {
                SpawnEvent spawnEvent = new SpawnEvent(Vector2.zero, 0f ,curSpawnInfo, 0f, 
                    playerSpawnRange, spawnLowerLimit, spawnUpperLimit);
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