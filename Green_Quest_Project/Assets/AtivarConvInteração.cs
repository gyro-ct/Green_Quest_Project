using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class AtivarConvInteração : MonoBehaviour
{
    public NPCConversation Dialogo;
    public bool ativada = false;

    private void Update() {
        if (ativada && Input.GetKeyDown(KeyCode.Space)){
            ConversationManager.Instance.StartConversation(Dialogo);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ativada = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            ativada = false;
        }
    }
}

