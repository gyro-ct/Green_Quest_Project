using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class filtroSpecialCollider : MonoBehaviour
{
    public NPCConversation conv;

    private void OnDestroy() {
        Debug.Log("OnDestroy");
        KanoController.instance.valor = 2;
        QuestManager.questManager.AddQuestItem("Achar filtro G3", 1);
        ConversationManager.Instance.StartConversation(conv);
        ArahController.instance.valor = 3;
    }
}
