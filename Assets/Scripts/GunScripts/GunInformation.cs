﻿
namespace GunScripts
{
    public struct GunInformation
    {
        public float gunDamage;
        public float gunFireRate;
        public float bulletSpeed;

        public GunInformation(float gunDamage, float gunFireRate, float bulletSpeed)
        {
            this.gunDamage = gunDamage;
            this.gunFireRate = gunFireRate;
            this.bulletSpeed = bulletSpeed;
        }
    
    }
}
