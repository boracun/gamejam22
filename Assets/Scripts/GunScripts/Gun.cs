using System;
using GameManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GunScripts
{
    public class Gun : MonoBehaviour
    {
        public const float MAX_EVOLUTION_POINTS = 100;
        public const float MAX_FP_POINTS = 5;
        public const float MAX_FR_POINTS = 5;
        
        public float gunHealth;
        public float maxGunHealth;
        public float gunDamage;
        public float gunFireRate;
        public float bulletSpeed;
        public float evolutionPoints;
        public float gunEvoFPPoints;
        public float gunEvoFRPoints;

        public IGunState GunState;
        public Camera camera;

        private bool fired = false;
        private float firedTimer = 0f;

        public float healthIncreaseAmount;

        public AudioSource src;
        

        // Start is called before the first frame update
        void Start()
        {
            GunState = new NormalGun();
            src = gameObject.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (gunHealth <= 0)
            {
                SceneManager.LoadSceneAsync("GameOver");
            }
            if (fired)
            {
                firedTimer += Time.deltaTime;

                float firePerSecond = 60 / (gunFireRate * GAM.Instance.gunAbilityFireRateBonus);

                if (firedTimer >= firePerSecond)
                {
                    firedTimer = 0f;
                    fired = false;
                }
            }
            if (Input.GetMouseButton(0) && !fired)
            {
                fired = true;
                
                Vector3 mouseVector = camera.ScreenToWorldPoint(Input.mousePosition);
                var gameObj = gameObject;
                Vector3 playerVector = gameObj.transform.position;
                MouseClickInformation mouseClickInformation = new MouseClickInformation(playerVector, mouseVector);
                GunInformation gunInformation = new GunInformation(gunDamage, gunFireRate, bulletSpeed, gameObj.transform, src);
            
                GunState.StateTrigger(gunInformation, mouseClickInformation); //Aka Shoot most probably in our demo
            }
        }
    }
}

