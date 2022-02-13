
using UnityEngine;

namespace GunScripts
{
    public struct GunInformation
    {
        public float gunDamage;
        public float gunFireRate;
        public float bulletSpeed;

        public Transform GunTransform;
        public AudioSource src;

        public GunInformation(float gunDamage, float gunFireRate, float bulletSpeed, Transform gunTransform, AudioSource src)
        {
            this.gunDamage = gunDamage;
            this.gunFireRate = gunFireRate;
            this.bulletSpeed = bulletSpeed;
            GunTransform = gunTransform;
            this.src = src; 
        }
    
    }
}
