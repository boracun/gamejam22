﻿using System;
using GunScripts;
using UnityEngine;


public class EvolutionManager : MonoBehaviour
{
    [SerializeField]
    public static float evoPointByKill;

    public float evolveIncreaseAmount;
    public float evolveTreshHold;
    
    public Gun Gun;

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
        EvolveGun();
    }
    
    public void EvolveFR()
    {
        HUD.Instance.IncreaseFR(1);
        Gun.gunFireRate += evolveIncreaseAmount;
        EvolveGun();
    }

    public void EvolveGun()
    {
        if (Gun.gunEvoFPPoints == evolveTreshHold && Gun.gunEvoFRPoints == evolveTreshHold)
        {
            
        }
        else if (Gun.gunEvoFPPoints == evolveTreshHold)
        {
            
        }
        else if (Gun.gunEvoFRPoints == evolveTreshHold)
        {
            
        }
    }
}