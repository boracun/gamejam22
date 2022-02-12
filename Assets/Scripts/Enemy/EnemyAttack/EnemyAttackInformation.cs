using UnityEngine;

namespace Enemy
{
    public struct EnemyAttackInformation
    {
        public GameObject playerObject;
        public EnemyProperties enemyProperties;

        public EnemyAttackInformation(GameObject playerObject, EnemyProperties enemyProperties)
        {
            this.enemyProperties = enemyProperties;
            this.playerObject = playerObject;
        }
    }
}