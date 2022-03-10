using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] float startTime = 5f;
    
    [SerializeField] TextMeshProUGUI timerText;

    float timer = 0f;
    void Start()
    {
        StartCoroutine(Timer());
    }
    private IEnumerator Timer(){
        timer = startTime;

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

        timerText.text = "";
        //timerText.text += seconds + ":" + miliseconds;
        //if (days > 0) {timerText.text += days + "d"; }
        //if (hours > 0) {timerText.text += hours + "h"; }
        //if (minutes > 0) {timerText.text += minutes + "m"; }
        if (seconds > 0) {timerText.text += seconds + ":" + miliseconds; }
        if (seconds <= 0 && miliseconds>0) {timerText.text += "0:" +  miliseconds; }
        if (miliseconds <= 0) {timerText.text += "0:" + "000"; }

    }

    
}
