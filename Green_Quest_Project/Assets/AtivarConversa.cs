using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class AtivarConversa : MonoBehaviour
{
    public NPCConversation myConversation;
    private bool mybool = true;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && mybool){
            mybool = false;
            PlayerController.instance.canMove = false;
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

    public void canMoveAgain(){
        PlayerController.instance.canMove = true;
        PlayerController.instance.canInteract = true;
    }
}
