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
        "quote1",
        "quote2",
        "quote3",
        "quote4",
        "quote5",
        "quote6",
        "quote7",
    };
    
    // Start is called before the first frame update
    void Start()
    {
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
