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

    public void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyProperties>().TakeDamage(GunInformation.gunDamage);
        Destroy(gameObject);
    }
}
