namespace Enemy
{
    public class NormalDamageTake : IEnemyDamageTakeBehavior
    {
        public void TakeDamage(float damageTaken, EnemyProperties enemyProperties)
        {
            enemyProperties.health -= damageTaken;
            if (enemyProperties.health <= 0)
            {
                enemyProperties.EnemyDie();
            }
        }
    }
}