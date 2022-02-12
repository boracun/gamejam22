using UnityEngine;

namespace Enemy
{
    public class NormalDeath : IEnemyDeathBehavior
    {
        public void Die(GameObject curObject)
        {
            GameObject.Destroy(curObject);
        }
    }
}