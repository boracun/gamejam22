using UnityEngine;

namespace GunScripts
{
    public class Gun : MonoBehaviour
    {
        public float gunDamage;
        public float gunFireRate;
        public float bulletSpeed;
    
        public GunState GunState;
        public Camera camera;
    
    
        // Start is called before the first frame update
        void Start()
        {
            GunState = new NormalGun();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mouseVector = camera.ScreenToWorldPoint(Input.mousePosition);
                Vector3 playerVector = gameObject.transform.position;
                MouseClickInformation mouseClickInformation = new MouseClickInformation(playerVector, mouseVector);
                GunInformation gunInformation = new GunInformation(gunDamage, gunFireRate, bulletSpeed);
            
                GunState.StateTrigger(gunInformation, mouseClickInformation); //Aka Shoot most probably in our demo

            }
        }
    }
}

