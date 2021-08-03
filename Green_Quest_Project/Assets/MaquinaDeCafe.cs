using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class MaquinaDeCafe : MonoBehaviour
{

    public bool playerIsNear = false;
    public GameObject coffee;
    public GameObject painelSave;

    void Update(){
        if (EvaController.instance.coffeMachineActivated && playerIsNear && Input.GetKeyDown(KeyCode.Space)){
            for (int i=0; i<QuestManager.questManager.currentQuestList.Count;i++){
                if (QuestManager.questManager.currentQuestList[i].id == 6){
                    coffee.SetActive(true);
                    painelSave.SetActive(true);
                }
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

}
