using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class AtivarConversa2 : MonoBehaviour
{
    public NPCConversation myConversation;
    private bool mybool = true;
    private bool myboolconv = false;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && myboolconv && mybool){
            mybool = false;
            PlayerController.instance.canMove = false;
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && mybool){
            myboolconv = true;
            PlayerController.instance.canInteract = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player" && mybool){
            myboolconv = false;
            PlayerController.instance.canInteract = true;
        }
    }

    public void canMoveAgain(){
        PlayerController.instance.canMove = true;
        PlayerController.instance.canInteract = true;
    }
}