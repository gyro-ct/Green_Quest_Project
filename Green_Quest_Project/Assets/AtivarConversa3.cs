using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class AtivarConversa3 : MonoBehaviour
{
    public NPCConversation myConversation;
    public bool mybool = false;
    
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("ENTROU");
        if (other.tag == "Player" && mybool){
            mybool = false;
            PlayerController.instance.canMove = false;
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
            PlayerController.instance.canMove = true;
    }

    public void canOpen(){
        mybool = true;
    }

    public void canMoveAgain(){
        PlayerController.instance.canMove = true;
    }
}
