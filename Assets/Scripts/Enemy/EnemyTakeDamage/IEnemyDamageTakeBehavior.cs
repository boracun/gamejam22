namespace Enemy
{
    public interface IEnemyDamageTakeBehavior
    {
        public void TakeDamage(float damageTaken, EnemyProperties enemyProperties);
    }
}