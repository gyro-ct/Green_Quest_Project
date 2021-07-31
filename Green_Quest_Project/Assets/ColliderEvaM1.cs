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
    public void ativarPorta6(){
        PortaManager.portaManager.AtivarPorta(6);
    }

    public void ativarPorta13(){
        PortaManager.portaManager.AtivarPorta(13);
    }

    // public GameObject colliderComp;
    public void ativarPorta7(){
        PortaManager.portaManager.AtivarPorta(7);
        ativarPC.instance.podeSerAtivado = false;
    }

    public void ativarPorta9(){
        PortaManager.portaManager.AtivarPorta(9);
    }

    public void ativarPorta14(){
        PortaManager.portaManager.AtivarPorta(14);
    }

    public void ativarPorta5(){
        PortaManager.portaManager.AtivarPorta(5);
    }

    public void ativarPorta17(){
        Debug.Log("FUNCIONAL");
        PortaManager.portaManager.AtivarPorta(17);
    }

    public void maisUmDiretor(){
        DiretorInstance.instance.aumentarValor();
    }

    public void next(){
        EvaController.instance.nextMove(true);
    }
}
