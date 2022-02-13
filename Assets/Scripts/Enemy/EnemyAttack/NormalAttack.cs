using GunScripts;
using UnityEngine;

namespace Enemy
{
    public class NormalAttack : IEnemyAttackBehavior
    {
        private float attackTimer;
        public void AttackPlayer(EnemyAttackInformation enemyAttackInformation)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= enemyAttackInformation.enemyProperties.attackCooldown)
            {
                attackTimer = 0f;
                GameObject player = enemyAttackInformation.playerObject;
                EnemyProperties enemyProperties = enemyAttackInformation.enemyProperties;
                HUD.Instance.DecreaseHealth(enemyProperties.damage);
            }
        }
    }
}