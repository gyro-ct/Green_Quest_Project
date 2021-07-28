using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Mother : MonoBehaviour
{
    public bool motherOfAllBools;

    public bool conversaFeita = false;
    public NPCConversation conversation;

    void Update()
    {
        if(motherOfAllBools && Input.GetKeyDown(KeyCode.Space)){
            
            if (QuestManager.questManager.ConversationMainTrigger == 1 &&
            !conversaFeita){
                Debug.Log("CC "+QuestManager.questManager.currentQuestList.Count);
                conversaFeita = true;
                QuestManager.questManager.AddQuestItem("Conversar com Mae", 1);
                PlayerController.instance.canMove = false;
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
