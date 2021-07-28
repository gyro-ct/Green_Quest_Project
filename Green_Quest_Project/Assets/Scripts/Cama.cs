using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cama : MonoBehaviour
{
    public bool waitToFade;
    public bool isTriggered;
    public float waitToLoad = 1f;
    private float numToSum;

    void Update(){
        if(isTriggered && Input.GetKeyDown(KeyCode.Space)){

            if (!Q101QuizManager.q101.TriggerforDormir){
                Q101QuizManager.q101.Ligacao();
            }

            waitToFade = true;
            UIFade.instance.fadeToBlack();
            PlayerController.instance.Stamina = 100f;
            List<GameObject> MyList = ProgressBarManager.ProgressBarInstance.getObjects();

            foreach (GameObject bar in MyList){
                Slider slider = bar.GetComponent<Slider>();
                numToSum = 100f - slider.value;
                bar.GetComponent<ProgressBar>().targetProgress = slider.value + numToSum;
                //bar.GetComponent<ProgressBar>().IncrementProgress(numToSum);
            }

            
        }
        if(waitToFade){
            waitToLoad -= 0.25f * Time.deltaTime;
            if(waitToLoad <= 0){
                waitToFade = false;
                waitToLoad = 1f;
                UIFade.instance.fadeFromBlack();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isTriggered = false;
        }
    }

}
