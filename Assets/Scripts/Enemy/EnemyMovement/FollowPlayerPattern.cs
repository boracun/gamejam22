using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Enemy
{
    public class FollowPlayerPattern : IMovingPattern
    {
        public void Move(EnemyMovementInformation enemyMovementInformation)
        {
            GameObject player = GameObject.Find("Panda");
            Vector2 playerVector = player.transform.position;
            Vector2 enemyVector = enemyMovementInformation.enemyTransform.position;
            Vector2 followVector = (playerVector - enemyVector).normalized;
            Rigidbody2D enemyRigidbody2D = enemyMovementInformation.enemyRigidbody2D;
            enemyRigidbody2D.velocity = followVector * enemyMovementInformation.enemySpeed;

            SpriteRenderer enemySr = enemyMovementInformation.enemySr;
            if (playerVector.x < enemyMovementInformation.enemyTransform.position.x) enemySr.flipX = true;
            else if (playerVector.x > enemyMovementInformation.enemyTransform.position.x) enemySr.flipX = false;
        }
    }
}