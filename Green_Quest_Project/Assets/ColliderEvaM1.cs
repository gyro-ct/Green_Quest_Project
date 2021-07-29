using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ColliderEvaM1 : MonoBehaviour
{

    public NPCConversation conversation1;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !PlayerController.instance.conversaComEva){
            //next();

            QuestManager.questManager.AddQuestItem("Conversar com Calenwen", 1);
            // QuestManager.questManager.CompleteQuest(4);

            PlayerController.instance.conversaComEva = true;
            PortaManager.portaManager.AtivarPorta(4); //Corredor
            //PortaManager.portaManager.AtivarPorta(8); //SGA
            PlayerController.instance.canMove = false;
            ConversationManager.Instance.StartConversation(conversation1);
        }
    }

    public void ativarPorta8(){
        PortaManager.portaManager.AtivarPorta(8);
    }

    public void next(){
        EvaController.instance.nextMove(true);
    }
}
