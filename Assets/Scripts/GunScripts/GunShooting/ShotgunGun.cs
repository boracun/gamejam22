using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GunScripts
{
    public class ShotgunGun : IGunState
    {
        public static Object prefab = Resources.Load("Prefabs/NormalProjectilePrefab");
        
        public void StateTrigger(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            Shoot(gunInformation, mouseClickInformation);
        }
        public void Shoot(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            GameObject NormalGunProjectile1 = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            GameObject NormalGunProjectile2 = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            GameObject NormalGunProjectile3 = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            
            NormalGunProjectile1.GetComponent<NormalGunProjectile>().GunInformation = gunInformation;
            NormalGunProjectile2.GetComponent<NormalGunProjectile>().GunInformation = gunInformation;
            NormalGunProjectile3.GetComponent<NormalGunProjectile>().GunInformation = gunInformation;
            
            Vector2 shootingVector1 = mouseClickInformation.GetPlayerMouseDistance();
            Vector2 shootingVector2 = mouseClickInformation.GetPlayerMouseDistance();
            Vector2 shootingVector3 = mouseClickInformation.GetPlayerMouseDistance();
            
            shootingVector2 = rotate(shootingVector2, (float)( Math.PI / 12));
            shootingVector3 = rotate(shootingVector3, (float)( -Math.PI / 12));
            Debug.Log(shootingVector1);
            Debug.Log(shootingVector2);
            Debug.Log(shootingVector2);
            
            NormalGunProjectile1.GetComponent<Rigidbody2D>().velocity = shootingVector1.normalized * gunInformation.bulletSpeed;
            NormalGunProjectile2.GetComponent<Rigidbody2D>().velocity = shootingVector2.normalized * gunInformation.bulletSpeed;
            NormalGunProjectile3.GetComponent<Rigidbody2D>().velocity = shootingVector3.normalized * gunInformation.bulletSpeed;
        }
        
        public static Vector2 rotate(Vector2 v, float delta) {
            return new Vector2(
                v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
                v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
            );
        }
    }
}