using System;
using System.Collections;
using System.Collections.Generic;
using GunScripts;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class HUD : MonoBehaviour
{
    private static HUD _instance;

    public static HUD Instance => _instance;

    //Right side
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text evolutionMeterText;
    [SerializeField]
    private Text pandaSpeechText;

    //Left side
    [SerializeField]
    private Text firepowerText;
    [SerializeField]
    private Text fireRateText;
    [SerializeField]
    private Button firepowerButton;
    [SerializeField]
    private Button fireRateButton;
    [SerializeField]
    private Image currentGun;

    private Gun _gun;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _gun = GameObject.FindGameObjectWithTag("Panda").transform.GetChild(0).GetComponent<Gun>();
    }

    public void IncreaseHealth(float increaseAmount)
    {
        _gun.gunHealth += increaseAmount;
        UpdateHealthText();
    }
    
    public void DecreaseHealth(float decreaseAmount)
    {
        _gun.gunHealth -= decreaseAmount;
        UpdateHealthText();
    }

    public void IncreaseEvolutionPoints(float increaseAmount)
    {
        _gun.evolutionPoints += increaseAmount;
        UpdateEvolutionPointsText();
    }

    public void ResetEvolutionPoints()
    {
        _gun.evolutionPoints = 0;
        UpdateEvolutionPointsText();
    }

    public void SetPandaSpeechText(String quote)
    {
        pandaSpeechText.text = quote;
    }
    
    public void EnableFPButton()
    {
        firepowerButton.interactable = true;
    }
    
    public void EnableFRButton()
    {
        fireRateButton.interactable = true;
    }

    public void IncreaseFP(float increaseAmount)
    {
        _gun.gunEvoFPPoints += increaseAmount;
        UpdateFPText();
    }
    
    public void IncreaseFR(float increaseAmount)
    {
        _gun.gunEvoFRPoints += increaseAmount;
        UpdateFRText();
    }
    
    public void DecreaseFP(float decreaseAmount)
    {
        _gun.gunEvoFPPoints -= decreaseAmount;
        UpdateFPText();
    }
    
    public void DecreaseFR(float decreaseAmount)
    {
        _gun.gunEvoFRPoints -= decreaseAmount;
        UpdateFRText();
    }

    private void UpdateHealthText()
    {
        healthText.text = _gun.gunHealth + "/" + _gun.maxGunHealth;
    }
    
    private void UpdateEvolutionPointsText()
    {
        evolutionMeterText.text = _gun.evolutionPoints + "/" + Gun.MAX_EVOLUTION_POINTS;
    }

    private void UpdateFPText()
    {
        firepowerText.text = _gun.gunEvoFPPoints + "/" + Gun.MAX_FP_POINTS;
    }
    
    private void UpdateFRText()
    {
        fireRateText.text = _gun.gunEvoFRPoints + "/" + Gun.MAX_FR_POINTS;
    }
}
