using UnityEngine;

namespace Enemy
{
    public interface IEnemyAttackBehavior
    {
        public void AttackPlayer(EnemyAttackInformation enemyAttackInformation);
    }
}