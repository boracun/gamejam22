using System;
using GunScripts;
using UnityEditor.Animations;
using UnityEngine;
using Object = UnityEngine.Object;


public class EvolutionManager : MonoBehaviour
{

    [SerializeField]
    public static float evoPointByKill;

    public float evolveIncreaseAmount;
    public float evolveTreshHold = Gun.MAX_FP_POINTS;

    public Sprite ShotgunSprite;
    public Sprite UziSprite;

    public GameObject gunModel;

    public AnimatorController ShotgunAnimation;
    public Gun Gun;


    public float shotgunDamageBoost;
    public float shotgunFireRatePunishment;

    

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
        HUD.Instance.ResetEvolutionPoints();
        EvolveGun();
    }
    
    public void EvolveFR()
    {
        HUD.Instance.IncreaseFR(1);
        HUD.Instance.ResetEvolutionPoints();
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

        Animator animator = gunModel.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Animations/Guns/Shotgun/Shotgun") as RuntimeAnimatorController;
        gunModel.GetComponent<SpriteRenderer>().sprite = ShotgunSprite;

    }
}