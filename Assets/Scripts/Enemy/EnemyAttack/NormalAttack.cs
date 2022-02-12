using UnityEngine;

namespace Enemy
{
    public class NormalAttack : IEnemyAttackBehavior
    {
        public void AttackPlayer(EnemyAttackInformation enemyAttackInformation)
        {
            GameObject player = enemyAttackInformation.playerObject;
            EnemyProperties enemyProperties = enemyAttackInformation.enemyProperties;
            player.GetComponent<PlayerProperties>().health -= enemyProperties.damage;
        }
    }
}