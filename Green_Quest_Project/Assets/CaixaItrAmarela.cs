using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaItrAmarela : MonoBehaviour
{
    public bool playerIsNear = false;

    void Update(){
        if (NebeliController.instance.isC1Activated && playerIsNear && Input.GetKeyDown(KeyCode.Space)){
            NebeliController.instance.pegarCaixa();
            Destroy(gameObject);
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
}
