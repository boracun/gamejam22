using Enemy;
using GameManagement;
using UnityEngine;

namespace GunScripts
{
    public class AKGun : IGunState
    {
        public static Object prefab = Resources.Load("Prefabs/AKGunProjectilePrefab");
        public void StateTrigger(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            Shoot(gunInformation, mouseClickInformation);
        }
        
        private void Shoot(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            GAM gam = GAM.Instance;
            GameObject AKGunProjectile = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            AKGunProjectile.transform.localScale += 
                (AKGunProjectile.transform.localScale*(gam.AKAbilityMultiplier * (gam.AKAbilityHitCount / gam.AKAbilityActivateRate)));
            
            AKGunProjectile.GetComponent<AKGunProjectile>().GunInformation = gunInformation;
            Vector2 shootingVector = mouseClickInformation.GetPlayerMouseDistance();
            Vector3 shootingVector3 = new Vector3(shootingVector.normalized.x, shootingVector.normalized.y);

            GameObject.Find("Panda").GetComponent<Transform>().position += 
                (-1*shootingVector3 * (gam.AKAbilityMultiplier * (gam.AKAbilityHitCount / gam.AKAbilityActivateRate)));
            
            shootingVector = rotate(shootingVector,
                (float) (EnemySpawnManager.random.NextDouble() 
                    * (gam.AKProjectileMaxRadian - (-1*gam.AKProjectileMaxRadian)) + (-1*gam.AKProjectileMaxRadian)));
            
            AKGunProjectile.GetComponent<Rigidbody2D>().velocity = shootingVector.normalized * gunInformation.bulletSpeed;
            gunInformation.src.Play();
        }
        
        public static Vector2 rotate(Vector2 v, float delta) {
            return new Vector2(
                v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
                v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
            );
        }
        
    }
}