using System;
using Enemy;
using GunScripts;
using UnityEngine;

public class NormalGunProjectile : MonoBehaviour
{
    public GunInformation GunInformation;
    public MouseClickInformation MouseClickInformation;
    public void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<EnemyProperties>().TakeDamage(GunInformation.gunDamage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag.Equals("Border"))
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        
    }
    
}
