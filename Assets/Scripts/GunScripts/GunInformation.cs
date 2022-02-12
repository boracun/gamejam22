
using UnityEngine;

namespace GunScripts
{
    public struct GunInformation
    {
        public float gunDamage;
        public float gunFireRate;
        public float bulletSpeed;

        public Transform GunTransform;

        public GunInformation(float gunDamage, float gunFireRate, float bulletSpeed, Transform gunTransform)
        {
            this.gunDamage = gunDamage;
            this.gunFireRate = gunFireRate;
            this.bulletSpeed = bulletSpeed;
            GunTransform = gunTransform;
        }
    
    }
}
