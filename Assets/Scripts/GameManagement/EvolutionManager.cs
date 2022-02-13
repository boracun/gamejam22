using System;
using GunScripts;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


public class EvolutionManager : MonoBehaviour
{

    [SerializeField]
    public static float evoPointByKill;

    public float evolveIncreaseAmount;
    public float evolveTreshHold = Gun.MAX_FP_POINTS;

    public Sprite ShotgunSprite;
    public Sprite UziSprite;
    public Sprite AKSprite;

    public GameObject gunModel;

    public AnimatorController ShotgunAnimation;
    public Gun Gun;


    public float shotgunDamageBoost;
    public float shotgunFireRatePunishment;
    
    public float uziDamagePunishment;
    public float uziFireRateBoost;

    public float AKDamageBonus;
    public float AKFireRateBonus;

    

    private void Update()
    {
        if (Gun.evolutionPoints >= Gun.MAX_EVOLUTION_POINTS)
        {
            HUD.Instance.EnableFPButton();
            HUD.Instance.EnableFRButton();

            if (Input.GetKey(KeyCode.Alpha1))
                HUD.Instance.ClickFPButton();
            else if (Input.GetKey(KeyCode.Alpha2))
                HUD.Instance.ClickFRButton();
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
            EvolveToAK();
        }
        else if (Gun.gunEvoFPPoints == evolveTreshHold)
        {
            EvolveToShotgun();
        }
        else if (Gun.gunEvoFRPoints == evolveTreshHold)
        {
            EvolveToUzi();
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
        
        GameObject gunImage = GameObject.Find("GunImage");
        gunImage.GetComponent<Image>().sprite = ShotgunSprite;
        Animator animator2 = gunImage.GetComponent<Animator>();
        animator2.runtimeAnimatorController = Resources.Load("Animations/Guns/Shotgun/Shotgun") as RuntimeAnimatorController;

    }
    
    private void EvolveToUzi()
    {
        Gun.GunState = new UziGun();
        Gun.gunDamage -= uziDamagePunishment;
        Gun.gunFireRate += uziFireRateBoost;

        Animator animator = gunModel.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Animations/Guns/Uzi/Uzi") as RuntimeAnimatorController;
        gunModel.GetComponent<SpriteRenderer>().sprite = UziSprite;
        
        GameObject gunImage = GameObject.Find("GunImage");
        gunImage.GetComponent<Image>().sprite = UziSprite;
        Animator animator2 = gunImage.GetComponent<Animator>();
        animator2.runtimeAnimatorController = Resources.Load("Animations/Guns/Uzi/Uzi") as RuntimeAnimatorController;

    }
    
    private void EvolveToAK()
    {
        Gun.GunState = new AKGun();
        Gun.gunDamage += AKDamageBonus;
        Gun.gunFireRate += AKFireRateBonus;

        Animator animator = gunModel.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Animations/Guns/AK/AK") as RuntimeAnimatorController;
        gunModel.GetComponent<SpriteRenderer>().sprite = AKSprite;
        
        GameObject gunImage = GameObject.Find("GunImage");
        gunImage.GetComponent<Image>().sprite = UziSprite;
        Animator animator2 = gunImage.GetComponent<Animator>();
        animator2.runtimeAnimatorController = Resources.Load("Animations/Guns/AK/AK") as RuntimeAnimatorController;

    }
}