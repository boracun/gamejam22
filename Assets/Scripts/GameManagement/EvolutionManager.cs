using System;
using GunScripts;
using UnityEngine;


public class EvolutionManager : MonoBehaviour
{
    [SerializeField]
    public static float evoPointByKill;

    public float evolveIncreaseAmount;
    public float evolveTreshHold;
    
    public Gun Gun;


    public float shotgunDamageBoost;
    public float shotgunFireRatePunishment;
    
    

    private void Update()
    {
        if (Gun.evolutionPoints >= Gun.MAX_EVOLUTION_POINTS)
        {
            HUD.Instance.EnableFPButton();
            HUD.Instance.EnableFRButton();
            HUD.Instance.ResetEvolutionPoints();
        }
    }

    public void EvolveFP()
    {
        HUD.Instance.IncreaseFP(1);
        Gun.gunDamage += evolveIncreaseAmount;
        HUD.Instance.ResetEvolutionPoints();
        EvolveGun();
    }
    
    public void EvolveFR()
    {
        HUD.Instance.IncreaseFR(1);
        Gun.gunFireRate += evolveIncreaseAmount;
        HUD.Instance.ResetEvolutionPoints();
        EvolveGun();
    }

    public void EvolveGun()
    {
        if (Gun.gunEvoFPPoints == evolveTreshHold && Gun.gunEvoFRPoints == evolveTreshHold)
        {
            
        }
        else if (Gun.gunEvoFPPoints == evolveTreshHold)
        {
            EvolveToShotgun();
        }
        else if (Gun.gunEvoFRPoints == evolveTreshHold)
        {
            
        }
    }

    private void EvolveToShotgun()
    {
        Gun.GunState = new ShotgunGun();
        Gun.gunDamage += shotgunDamageBoost;
        Gun.gunFireRate -= shotgunFireRatePunishment;
    }
}