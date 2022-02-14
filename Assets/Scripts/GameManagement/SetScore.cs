using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = HUD._score.ToString();
    }
}
