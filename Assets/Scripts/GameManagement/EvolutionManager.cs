using System;
using GunScripts;
using UnityEngine;


public class EvolutionManager : MonoBehaviour
{
    [SerializeField]
    public static float evoPointByKill;

    public float evolveIncreaseAmount;
    public float evolveTreshHold = Gun.MAX_FP_POINTS;
    
    public Gun Gun;

    private void Update()
    {
        if (Gun.evolutionPoints >= Gun.MAX_EVOLUTION_POINTS)
        {
            HUD.Instance.EnableFPButton();
            HUD.Instance.EnableFRButton();
        }
    }

    public void EvolveFP()
    {
        HUD.Instance.IncreaseFP(1);
        HUD.Instance.ResetEvolutionPoints();
        Gun.gunDamage += evolveIncreaseAmount;
        EvolveGun();
    }
    
    public void EvolveFR()
    {
        HUD.Instance.IncreaseFR(1);
        HUD.Instance.ResetEvolutionPoints();
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