using Enemy;
using GameManagement;
using UnityEngine;

namespace GunScripts
{
    public class AKGunProjectile : MonoBehaviour
    {
        public GunInformation GunInformation;
        public MouseClickInformation MouseClickInformation;
        public void Start()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            GAM gam = GAM.Instance;
            if (other.gameObject.tag.Equals("Enemy"))
            {
                gam.AKAbilityHitCount++;
                other.gameObject.GetComponent<EnemyProperties>().TakeDamage(GunInformation.gunDamage);
                Destroy(gameObject);
            }

            if (other.gameObject.tag.Equals("Border"))
            {
                gam.AKAbilityHitCount = 0f;
                Destroy(gameObject);
            }
        }
    }
}