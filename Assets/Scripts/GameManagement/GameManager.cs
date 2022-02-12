using System.Collections;
using System.Collections.Generic;
using Enemy;
using GameManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 10f)
        {
            SpawnInfo[] spawnInfos = new SpawnInfo[4];
            SpawnInfo spawnInfo = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), 0f, 0f, 0f);
            SpawnInfo spawnInfo2 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), 0f, 0f, 0f);
            SpawnInfo spawnInfo3 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), 0f, 0f, 0f);
            SpawnInfo spawnInfo4 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), 0f, 0f, 0f);
            spawnInfos[0] = spawnInfo;
            spawnInfos[1] = spawnInfo2;
            spawnInfos[2] = spawnInfo3;
            spawnInfos[3] = spawnInfo4;
            
            EnemySpawnManager.SpawnEnemies(spawnInfos);
            time = 0f;
        }
    }
}
