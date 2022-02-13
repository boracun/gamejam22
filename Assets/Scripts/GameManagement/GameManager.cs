using System.Collections;
using System.Collections.Generic;
using Enemy;
using GameManagement;
using GunScripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float time = 0f;

    public float spawnTime;
    private float waveLength;

    public Gun Gun;
    public float enemyHealthSpawn;
    public float healthMultiplier;

    public float enemySpeedSpawn;
    public float speedMultiplier;
    
    public EnemySpawnManager EnemySpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        waveLength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float enemyHealth = CalculateMultiplier() * enemyHealthSpawn + enemyHealthSpawn;
        float enemySpeed = CalculateSpeedMultiplier() * enemySpeedSpawn + enemySpeedSpawn;
        waveLength += Time.deltaTime;
        time += Time.deltaTime;

        if (waveLength <= 20)
        {
            if (time >= spawnTime)
            {
                SpawnInfo[] spawnInfos = new SpawnInfo[4];
                SpawnInfo spawnInfo = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo2 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo3 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo4 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                spawnInfos[0] = spawnInfo;
                spawnInfos[1] = spawnInfo2;
                spawnInfos[2] = spawnInfo3;
                spawnInfos[3] = spawnInfo4;

                EnemySpawnManager.SpawnEnemies(spawnInfos);
                time = 0f;
            }
        }
        else if (20 < waveLength && waveLength <= 30)
        {
            return;
        }
        else if (30 < waveLength && waveLength <= 60)
        {
            if (time >= spawnTime)
            {
                SpawnInfo[] spawnInfos = new SpawnInfo[4];
                SpawnInfo spawnInfo = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo2 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo3 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo4 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                spawnInfos[0] = spawnInfo;
                spawnInfos[1] = spawnInfo2;
                spawnInfos[2] = spawnInfo3;
                spawnInfos[3] = spawnInfo4;

                EnemySpawnManager.SpawnEnemies(spawnInfos);
                time = 0f;
            }
        }
        else if (60 < waveLength && waveLength <= 70)
        {
            return;
        }
        else if (70 < waveLength && waveLength <= 120)
        {
            if (time >= spawnTime)
            {
                SpawnInfo[] spawnInfos = new SpawnInfo[4];
                SpawnInfo spawnInfo = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, 0f);
                SpawnInfo spawnInfo2 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, 0f);
                SpawnInfo spawnInfo3 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, 0f);
                SpawnInfo spawnInfo4 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, 0f);
                spawnInfos[0] = spawnInfo;
                spawnInfos[1] = spawnInfo2;
                spawnInfos[2] = spawnInfo3;
                spawnInfos[3] = spawnInfo4;

                EnemySpawnManager.SpawnEnemies(spawnInfos);
                time = 0f;
            }
        }
        else if (120 < waveLength && waveLength <= 130)
        {
            return;
        }
        else if (130 < waveLength && waveLength <= 190)
        {
            if (time >= spawnTime)
            {
                SpawnInfo[] spawnInfos = new SpawnInfo[4];
                SpawnInfo spawnInfo = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, 0f);
                SpawnInfo spawnInfo2 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, 0f);
                SpawnInfo spawnInfo3 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, 0f);
                SpawnInfo spawnInfo4 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, 0f);
                spawnInfos[0] = spawnInfo;
                spawnInfos[1] = spawnInfo2;
                spawnInfos[2] = spawnInfo3;
                spawnInfos[3] = spawnInfo4;

                EnemySpawnManager.SpawnEnemies(spawnInfos);
                time = 0f;
            }
        }
        else if (190 < waveLength && waveLength <= 200)
        {
            return;
        }
        else if (200 < waveLength)
        {
            if (time >= spawnTime)
            {
                SpawnInfo[] spawnInfos = new SpawnInfo[4];
                SpawnInfo spawnInfo = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo2 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo3 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                SpawnInfo spawnInfo4 = new SpawnInfo(EnemyType.NormalEnemy, new RandomSpawn(), enemyHealth, 0f, enemySpeed);
                spawnInfos[0] = spawnInfo;
                spawnInfos[1] = spawnInfo2;
                spawnInfos[2] = spawnInfo3;
                spawnInfos[3] = spawnInfo4;

                EnemySpawnManager.SpawnEnemies(spawnInfos);
                time = 0f;
            }
        }
    }

    public float CalculateMultiplier()
    {
        float totalEvo = Gun.gunEvoFPPoints + Gun.gunEvoFRPoints;
        return totalEvo * healthMultiplier;
    }
    
    public float CalculateSpeedMultiplier()
    {
        float totalEvo = Gun.gunEvoFPPoints + Gun.gunEvoFRPoints;
        return totalEvo * speedMultiplier;
    }
}
