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

    public GameObject gunModel;

    public AnimatorController ShotgunAnimation;
    public Gun Gun;
    
    public float shotgunDamageBoost;
    public float shotgunFireRatePunishment;
    
    public float uziDamagePunishment;
    public float uziFireRateBoost;
    
    //Top-left images
    public GameObject defaultGunImage;
    public GameObject shotgunImage;
    public GameObject uziImage;
    public GameObject akImage;

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
        
        defaultGunImage.SetActive(false);
        uziImage.SetActive(false);
        akImage.SetActive(false);
        shotgunImage.SetActive(true);
    }
    
    private void EvolveToUzi()
    {
        Gun.GunState = new UziGun();
        Gun.gunDamage -= uziDamagePunishment;
        Gun.gunFireRate += uziFireRateBoost;

        Animator animator = gunModel.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Animations/Guns/Uzi/Uzi") as RuntimeAnimatorController;
        gunModel.GetComponent<SpriteRenderer>().sprite = UziSprite;
        
        defaultGunImage.SetActive(false);
        shotgunImage.SetActive(false);
        akImage.SetActive(false);
        uziImage.SetActive(true);
    }
}