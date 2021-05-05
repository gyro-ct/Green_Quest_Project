using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cama : MonoBehaviour
{
    public bool waitToFade;
    public bool isTriggered;
    public float waitToLoad = 1f;

    void Update(){
        if(isTriggered && Input.GetKeyDown(KeyCode.Space)){
            waitToFade = true;
            UIFade.instance.fadeToBlack();
            PlayerController.instance.Stamina = 100f;
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
