using System;
using UnityEngine;

namespace GunScripts
{
    public class Gun : MonoBehaviour
    {
        //gun movement
        public Rigidbody2D rb_g;
        public SpriteRenderer sr_g;
        private Vector3 gunDirection;

        public float gunHealth;
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

            // gun rotatation
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            gunDirection = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - gunDirection.x;
            mousePos.y = mousePos.y - gunDirection.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            if (worldPosition.x < transform.position.x) 
            {
                sr_g.flipX = true;
                mousePos = Input.mousePosition;
                mousePos.z = 5.23f;

                gunDirection = Camera.main.WorldToScreenPoint(transform.position);
                mousePos.x = gunDirection.x - mousePos.x;
                mousePos.y = gunDirection.y - mousePos.y;

                angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
            else if (worldPosition.x > transform.position.x) sr_g.flipX = false;
        }
    }
}

