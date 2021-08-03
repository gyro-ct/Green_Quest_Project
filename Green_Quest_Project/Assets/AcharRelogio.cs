using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class AcharRelogio : MonoBehaviour
{
    public NPCConversation conv;
    private void OnDestroy() {
        if (NibilaController.instance.achouRelogio){
            Debug.Log("OnDestroy");
            ConversationManager.Instance.StartConversation(conv);
        }
    }
}
