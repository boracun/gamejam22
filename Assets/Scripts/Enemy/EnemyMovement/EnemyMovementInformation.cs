using UnityEngine;

namespace Enemy
{
    public struct EnemyMovementInformation
    {
        public Rigidbody2D enemyRigidbody2D;
        public Transform enemyTransform;
        public float enemySpeed;

        public EnemyMovementInformation(Transform enemyTransform, float enemySpeed, Rigidbody2D enemyRigidbody2D)
        {
            this.enemyTransform = enemyTransform;
            this.enemySpeed = enemySpeed;
            this.enemyRigidbody2D = enemyRigidbody2D;
        }
    }
}