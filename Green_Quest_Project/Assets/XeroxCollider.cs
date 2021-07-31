using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XeroxCollider : MonoBehaviour
{
    public GameObject itemParaPegar; 
    public bool isPlayerNear = false;
    private void Update() {
        if(BrenesController.instance.ativarXerox && isPlayerNear && Input.GetKeyDown(KeyCode.Space)){
            itemParaPegar.SetActive(true);
        }       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            isPlayerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            isPlayerNear = false;
        }
    }
}
