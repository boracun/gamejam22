using System;
using Enemy;
using UnityEngine;

namespace GunScripts
{
    public class ShotgunGunProjectile : MonoBehaviour
    {
        public float projectileDestroyTime;
        private float destroyTimer;
        public float shotgunKnockback;
        public GunInformation GunInformation;
        public MouseClickInformation MouseClickInformation;
        public void Start()
        {
        }

        private void Update()
        {
            destroyTimer += Time.deltaTime;
            if (projectileDestroyTime <= destroyTimer)
            {
                Destroy(gameObject);
                destroyTimer = 0f;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Enemy"))
            {
                other.gameObject.GetComponent<EnemyProperties>().TakeDamage(GunInformation.gunDamage);
                Vector2 shootingVector = MouseClickInformation.GetPlayerMouseDistance().normalized;
                Vector3 shootingVector3 = new Vector3(shootingVector.x, shootingVector.y, 0);
                other.gameObject.transform.position += shootingVector3 * shotgunKnockback;
                Destroy(gameObject);
            }

            if (other.gameObject.tag.Equals("Border"))
            {
                Destroy(gameObject);
            }
        }
        
    }
}