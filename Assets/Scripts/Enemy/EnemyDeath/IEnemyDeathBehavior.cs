using UnityEngine;

namespace Enemy
{
    public interface IEnemyDeathBehavior
    {
        public void Die(GameObject curObject);
    }
}