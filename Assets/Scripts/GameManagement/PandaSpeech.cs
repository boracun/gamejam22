using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PandaSpeech : MonoBehaviour
{
    private int _currentQuoteIndex;
    private List<String> _quoteList = new List<string>()
    {
        "Press 1 and 2 keys to use upgrade buttons",
        "Upgrade firepower to get powerful guns",
        "Upgrade fire rate to get faster guns",
        "I trust you!",
        "If you wait 5 seconds without shooting fast gun, it gets faster",
        "5 accurate shots with the machine gun gives bigger bullets",
        "Your health regenerates in every x score",
    };
    
    // Start is called before the first frame update
    void Start()
    {
        HUD.Instance.SetPandaSpeechText(_quoteList[0]);
        _currentQuoteIndex = 0;
        StartCoroutine(ChangeQuote());
    }

    IEnumerator ChangeQuote()
    {
        while (true)
        {
            var random = new Random();
            int index;
            do
            {
                index = random.Next(_quoteList.Count);
            } while(index == _currentQuoteIndex);

            yield return new WaitForSeconds(15);
        
            HUD.Instance.SetPandaSpeechText(_quoteList[index]);
        }
    }
}
