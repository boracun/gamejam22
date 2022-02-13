using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GunScripts
{
    public class ShotgunGun : IGunState
    {
        public static Object prefab = Resources.Load("Prefabs/ShotgunProjectilePrefab");
        
        public void StateTrigger(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            Shoot(gunInformation, mouseClickInformation);
        }
        public void Shoot(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            GameObject ShotgunGunProjectile1 = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            GameObject ShotgunGunProjectile2 = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            GameObject ShotgunGunProjectile3 = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            
            ShotgunGunProjectile1.GetComponent<ShotgunGunProjectile>().GunInformation = gunInformation;
            ShotgunGunProjectile2.GetComponent<ShotgunGunProjectile>().GunInformation = gunInformation;
            ShotgunGunProjectile3.GetComponent<ShotgunGunProjectile>().GunInformation = gunInformation;
            
            ShotgunGunProjectile1.GetComponent<ShotgunGunProjectile>().MouseClickInformation = mouseClickInformation;
            ShotgunGunProjectile2.GetComponent<ShotgunGunProjectile>().MouseClickInformation = mouseClickInformation;
            ShotgunGunProjectile3.GetComponent<ShotgunGunProjectile>().MouseClickInformation = mouseClickInformation;
            
            Vector2 shootingVector1 = mouseClickInformation.GetPlayerMouseDistance();
            Vector2 shootingVector2 = mouseClickInformation.GetPlayerMouseDistance();
            Vector2 shootingVector3 = mouseClickInformation.GetPlayerMouseDistance();
            
            shootingVector2 = rotate(shootingVector2, (float)( Math.PI / 12));
            shootingVector3 = rotate(shootingVector3, (float)( -Math.PI / 12));

            ShotgunGunProjectile1.GetComponent<Rigidbody2D>().velocity = shootingVector1.normalized * gunInformation.bulletSpeed;
            ShotgunGunProjectile2.GetComponent<Rigidbody2D>().velocity = shootingVector2.normalized * gunInformation.bulletSpeed;
            ShotgunGunProjectile3.GetComponent<Rigidbody2D>().velocity = shootingVector3.normalized * gunInformation.bulletSpeed;
            
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