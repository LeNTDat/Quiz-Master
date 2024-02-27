using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timeToCompleteQuestion = 20.0f;
    float timeShowCorrectQuestion = 5.0f;
    float timerValue;
    public float fillFraction { get; set; }
    
    bool isAnsweringQuestion;
    public bool isAnswering {
        get { return isAnsweringQuestion; } 
        set { isAnsweringQuestion = value; } 
    }

    bool loadQuestion;
    public bool loadNextQuestion {
        get { return loadQuestion; }
        set { loadQuestion = value; }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
  

    void UpdateTimer()
{
        timerValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                timerValue = timeShowCorrectQuestion;
                isAnsweringQuestion = false;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeShowCorrectQuestion;

            }
            else
            {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadQuestion = true;
            }
        }
        
    }
}
