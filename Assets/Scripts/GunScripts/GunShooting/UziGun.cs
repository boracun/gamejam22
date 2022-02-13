using GameManagement;
using UnityEngine;

namespace GunScripts
{
    public class UziGun : IGunState
    {
        public static Object prefab = Resources.Load("Prefabs/UziProjectilePrefab");

        public void StateTrigger(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            Shoot(gunInformation, mouseClickInformation);
        }
    

        private void Shoot(GunInformation gunInformation, MouseClickInformation mouseClickInformation)
        {
            GAM gam = GAM.Instance;
            if (gam.uziPowerTimer >= gam.uziPowerCooldown)
            {
                gam.gunAbilityFireRateBonus = 2f;
                if (gam.uziPowerTimer >= gam.uziPowerAbilityTime + gam.uziPowerCooldown)
                {
                    gam.uziPowerTimer = 0f;
                }
            }
            else
            {
                gam.gunAbilityFireRateBonus = 1f;
                gam.uziPowerTimer = 0f;
            }
            GameObject uziGunProjectile = GameObject.Instantiate(prefab, gunInformation.GunTransform) as GameObject;
            uziGunProjectile.GetComponent<UziGunProjectile>().GunInformation = gunInformation;
            Vector2 shootingVector = mouseClickInformation.GetPlayerMouseDistance();
            uziGunProjectile.GetComponent<Rigidbody2D>().velocity = shootingVector.normalized * gunInformation.bulletSpeed;

            gunInformation.src.Play();
        }
    }
}