using GunScripts;
using UnityEngine;

namespace Enemy
{
    public class NormalAttack : IEnemyAttackBehavior
    {
        public void AttackPlayer(EnemyAttackInformation enemyAttackInformation)
        {
            GameObject player = enemyAttackInformation.playerObject;
            EnemyProperties enemyProperties = enemyAttackInformation.enemyProperties;
            HUD.Instance.DecreaseHealth(enemyProperties.damage);
        }
    }
}