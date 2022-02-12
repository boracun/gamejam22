using Enemy;

namespace GameManagement
{
    public struct SpawnInfo
    {
        public EnemyType enemyType;
        public ISpawnBehavior spawnBehavior;
        public float enemyHealth;
        public float enemyDamage;
        public float enemySpeed;

        public SpawnInfo(EnemyType enemyType, ISpawnBehavior spawnBehavior, float enemyHealth, 
            float enemyDamage, float enemySpeed)
        {
            this.enemyType = enemyType;
            this.spawnBehavior = spawnBehavior;
            this.enemyHealth = enemyHealth;
            this.enemyDamage = enemyDamage;
            this.enemySpeed = enemySpeed;
        }
    }
}