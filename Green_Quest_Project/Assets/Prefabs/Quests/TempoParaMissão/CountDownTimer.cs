using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public GameObject TextTime;
    public Text textDisplay;
    public GameObject TimesUpDisplay;
    public float Tempo;
    public bool takingAway = true;
    public bool TimesUp = false;
    public bool StopTheTime;

    void Start()
    {
        textDisplay.text = Tempo + " seg";
    }

    void Update()
    {
        if (takingAway == true && Tempo > -1)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = false;
        yield return new WaitForSeconds(1);
        Tempo -= 1;

        if(Tempo >= 10)
        {
            textDisplay.text =  Tempo + " seg" ;
            
        }
        if(Tempo == 2) //Teste de parada!
        {
            StopTime();
        }
        if (Tempo < 10)
        {
            textDisplay.color = Color.red;
            textDisplay.transform.localScale = new Vector3 (1.1f,1.1f,0);
            textDisplay.text = "0" + Tempo + " seg";
        }
        if (Tempo == -1)
        {
            TimesUp = true;
            Destroy(TextTime);
            TimesUpDisplay.SetActive(true);
        }
        if (StopTheTime == true)
        {
            yield break;
        }
        takingAway = true;
    }

    public void StopTime()
    {
        StopTheTime = true;
    }
}
