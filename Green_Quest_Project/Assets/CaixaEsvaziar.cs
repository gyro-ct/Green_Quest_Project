using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaEsvaziar : MonoBehaviour
{
    public bool isActivated = true;
    public bool playerIsNear = false;
    public GameObject papel1;
    public GameObject papel2;
    public GameObject papel3;
    public GameObject papel4;

    public int contador = 1;

    public static CaixaEsvaziar instance;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
    }

    void Update(){
        if (isActivated && playerIsNear && Input.GetKeyDown(KeyCode.Space)){
            if (contador == 1){
                papel1.SetActive(true);
                isActivated = false;
                contador = 2;
            } else if (contador == 2){
                papel2.SetActive(true);
                isActivated = false;
                contador = 3;
            } else if (contador == 3){
                papel3.SetActive(true);
                isActivated = false;
                contador = 4;
            } else if (contador == 4){
                papel4.SetActive(true);
                isActivated = false;
                contador = 5;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            playerIsNear = false;
        }
    }
    public void selfDestroy(){
        Destroy(gameObject);
    }
    public void activatePapel(){
        CaixaEsvaziar.instance.isActivated = true;
    }
    public void deactivatePapel(){
        CaixaEsvaziar.instance.isActivated = false;
    }
}
