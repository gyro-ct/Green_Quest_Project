using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateNibila : MonoBehaviour
{
    public bool activateIt = false;
    
    void Update()
    {
        if (activateIt && NibilaController.instance.oneTimer){
            NibilaController.instance.oneTimer = false;
            NibilaController.instance.ativarConversa();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            activateIt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            activateIt = false;
        }
    }

}
