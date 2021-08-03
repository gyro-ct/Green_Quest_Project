using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class filtroSpecialCollider : MonoBehaviour
{
    public NPCConversation conv;
    private void OnDestroy() {
        if (KanoController.instance.achouFiltro){
            ConversationManager.Instance.StartConversation(conv);
        }
    }
}
