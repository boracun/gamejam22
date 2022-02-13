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
        healthText.text = _gun.gunHealth + "/" + _gun.maxGunHealth;
    }
    
    public void DecreaseHealth(float decreaseAmount)
    {
        _gun.gunHealth -= decreaseAmount;
        healthText.text = _gun.gunHealth + "/" + _gun.maxGunHealth;
    }
}
