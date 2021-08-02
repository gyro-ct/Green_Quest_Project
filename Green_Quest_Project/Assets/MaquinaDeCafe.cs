using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class MaquinaDeCafe : MonoBehaviour
{

    public bool isActivated = false;

    public bool playerIsNear = false;
    public GameObject coffee;
    public GameObject painelSave;

    void Update(){
        if (isActivated && playerIsNear && Input.GetKeyDown(KeyCode.Space)){
            if (QuestManager.questManager.ConversationMainTrigger == 5){
                coffee.SetActive(true);
                painelSave.SetActive(true);
            }
            // IMPLEMENTAR
            // SaveLoadQuitGame.saveLoadQuitGame.Save();
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

    public void activateCoffeeMachine(){
        isActivated = true;
    }
    public void deactivateCoffeeMachine(){
        isActivated = false;
    }

}
