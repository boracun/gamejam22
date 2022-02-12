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
            Debug.Log(enemyRigidbody2D.velocity.magnitude);
        }
    }
}