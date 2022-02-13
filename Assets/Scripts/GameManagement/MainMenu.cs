using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        SceneManager.UnloadScene("SampleScene");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
