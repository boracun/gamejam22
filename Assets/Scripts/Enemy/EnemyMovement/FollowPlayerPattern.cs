using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Enemy
{
    public class FollowPlayerPattern : IMovingPattern
    {
        public void Move(EnemyMovementInformation enemyMovementInformation)
        {
            GameObject player = GameObject.Find("Panda");
            Vector3 playerVector = player.transform.position;
            Vector2 followVector = (playerVector - enemyMovementInformation.enemyTransform.position).normalized;
            Rigidbody2D enemyRigidbody2D = enemyMovementInformation.enemyRigidbody2D;
            enemyRigidbody2D.velocity = followVector * enemyMovementInformation.enemySpeed;
        }
    }
}