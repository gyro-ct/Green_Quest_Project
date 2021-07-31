using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class AcarItm2 : MonoBehaviour
{
    public NPCConversation conv;

    private void OnDestroy() {
        Debug.Log("OnDestroy");
        ConversationManager.Instance.StartConversation(conv);
    }
}
