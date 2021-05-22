using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Mother : MonoBehaviour
{
    public bool motherOfAllBools;
    public NPCConversation conversation;
    public NPCConversation conversation2;
    void Update()
    {
        if(motherOfAllBools && Input.GetKeyDown(KeyCode.Space)){
            if (QuestManager.questManager.mother){
                Debug.Log("CONV2");
                ConversationManager.Instance.StartConversation(conversation2);
                QuestManager.questManager.mother = false;
            } else {
                Debug.Log("CONV");
                Debug.Log("CC "+QuestManager.questManager.currentQuestList.Count);
                ConversationManager.Instance.StartConversation(conversation);
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            Debug.Log("PLAYERMOTHER");
            motherOfAllBools = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if (col.tag == "Player"){
            motherOfAllBools = false;
        }
    }

}
