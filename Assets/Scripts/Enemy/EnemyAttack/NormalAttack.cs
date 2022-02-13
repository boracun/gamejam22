using GunScripts;
using UnityEngine;

namespace Enemy
{
    public class NormalAttack : IEnemyAttackBehavior
    {
        public void AttackPlayer(EnemyAttackInformation enemyAttackInformation)
        {
            EnemyProperties enemyProperties = enemyAttackInformation.enemyProperties;
            HUD.Instance.DecreaseHealth(enemyProperties.damage);
        }
    }
}