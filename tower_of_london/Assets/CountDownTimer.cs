using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    //[SerializeField] float startTime = 5f; // Set start time in unity 
    
    [SerializeField] TextMeshProUGUI timerText;

    float timer = 5f; // Set start time
    void Start()
    {
        StartCoroutine(Timer());
    }
    private IEnumerator Timer(){
        //timer = startTime; // if start time is set in unity

        do{
            timer -= Time.deltaTime;
            FormatText();
            yield return null;

        }
        while(timer > 0);
    }

    private void FormatText(){
        int days = (int)(timer / 86400000) % 365;
        int hours = (int)(timer / 3600000) % 24;
        int minutes = (int)(timer / 60000) % 60;
        int seconds = (int)(timer % 60);
        int miliseconds = (int)(timer * 1000) % 1000;

        timerText.text = ""; // DO NOT REMOVE, fixes spam error 
        if (seconds > 0) {timerText.text += seconds + ":" + miliseconds; }
        if (seconds <= 0 && miliseconds>0) {timerText.text += "0:" +  miliseconds; }
        if (miliseconds <= 0) {timerText.text += "0:" + "000"; }

    }

    
}
