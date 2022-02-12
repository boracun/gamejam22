using System;
using UnityEngine;

namespace GunScripts
{
    public class Gun : MonoBehaviour
    {
        public float gunDamage;
        public float gunFireRate;
        public float bulletSpeed;
    
        public IGunState GunState;
        public Camera camera;

        private bool fired = false;
        private float firedTimer = 0f;
    
    
        // Start is called before the first frame update
        void Start()
        {
            GunState = new NormalGun();
        }

        // Update is called once per frame
        void Update()
        {
            if (fired)
            {
                firedTimer += Time.deltaTime;

                float firePerSecond = 60 / gunFireRate;

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
                GunInformation gunInformation = new GunInformation(gunDamage, gunFireRate, bulletSpeed, gameObj.transform);
            
                GunState.StateTrigger(gunInformation, mouseClickInformation); //Aka Shoot most probably in our demo

            }
        }
    }
}

