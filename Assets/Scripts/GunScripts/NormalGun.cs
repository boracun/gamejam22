using UnityEngine;

namespace GunScripts
{
    public class NormalGun : GunState
    {
        public static Object prefab = Resources.Load("Prefabs/NormalProjectilePrefab");
        
        public void StateTrigger(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            Shoot(gunInformation, mouseClickInformation);
        }
    

        private void Shoot(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            Debug.Log(mouseClickInformation.mouseVector);
            GameObject NormalGunProjectile = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            NormalGunProjectile.GetComponent<NormalGunProjectile>().GunInformation = gunInformation;
            Vector2 shootingVector = mouseClickInformation.GetPlayerMouseDistance();
            NormalGunProjectile.GetComponent<Rigidbody2D>().AddForce(shootingVector.normalized * gunInformation.bulletSpeed);

        }
    
    
    }
}
