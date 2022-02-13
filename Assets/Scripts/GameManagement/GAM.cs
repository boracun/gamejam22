using System;
using UnityEngine;

namespace GameManagement
{
    public class GAM : MonoBehaviour
    {
        private static GAM _instance;

        public static GAM Instance => _instance;
        
        public float uziPowerTimer;
        public float uziPowerCooldown;
        public float uziPowerAbilityTime;
        public float gunAbilityFireRateBonus;

        public float AKProjectileMaxRadian = Mathf.PI/48;

        public float AKAbilityHitCount;
        public float AKAbilityMultiplier;
        public float AKAbilityActivateRate;

        private void Awake()
        {
            _instance = this;
        }
        private void Update()
        {
            uziPowerTimer += Time.deltaTime;
        }
    }
}