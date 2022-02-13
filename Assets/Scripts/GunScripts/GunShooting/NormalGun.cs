using UnityEngine;

namespace GunScripts
{
    public class NormalGun : IGunState
    {
        public static Object prefab = Resources.Load("Prefabs/NormalProjectilePrefab");
        
        public void StateTrigger(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            Shoot(gunInformation, mouseClickInformation);
        }
    

        private void Shoot(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            GameObject NormalGunProjectile = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            NormalGunProjectile.GetComponent<NormalGunProjectile>().GunInformation = gunInformation;
            Vector2 shootingVector = mouseClickInformation.GetPlayerMouseDistance();
            NormalGunProjectile.GetComponent<Rigidbody2D>().velocity = shootingVector.normalized * gunInformation.bulletSpeed;

        }
    
    
    }
}
