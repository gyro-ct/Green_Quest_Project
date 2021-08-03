using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrNexusSemiController : MonoBehaviour
{
    public bool ativada = false;

    private void Update() {
        if (ativada && Input.GetKeyDown(KeyCode.Space)){
            if (NibilaController.instance.valorSrNexus == 1 && NibilaController.instance.vn1){
                NibilaController.instance.vn1 = false; //
                PlayerController.instance.C2();
                PlayerController.instance.canInteract = false;
                QuestManager.questManager.AddQuestItem("Conversar com o Sr. Nexus", 1);
                NibilaController.instance.ativarConvNexus1();
            } else if (NibilaController.instance.valorSrNexus == 2 && NibilaController.instance.vn2) {
                NibilaController.instance.vn2 = false;
                PlayerController.instance.C2();
                PlayerController.instance.canInteract = false;
                NibilaController.instance.ativarConvNexus2();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            ativada = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            ativada = false;
        }
    }
}
