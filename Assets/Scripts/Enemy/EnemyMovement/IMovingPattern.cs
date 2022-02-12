using UnityEngine;

namespace Enemy
{
    public interface IMovingPattern
    {
        public void Move(EnemyMovementInformation enemyMovementInformation);
    }
}