using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ColliderEvaM1 : MonoBehaviour
{

    public NPCConversation conversation1;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && EvaController.instance.isColliderActive){
            EvaController.instance.isColliderActive = false;
            QuestManager.questManager.ShowQuestProvisoryCanvas(5);
            PlayerController.instance.canMove = false;
            PlayerController.instance.canInteract = false;
        }
    }

    public void ativarPorta4(){
        PortaManager.portaManager.AtivarPorta(4);
    }
    public void desativarPorta18(){
        PortaManager.portaManager.DesativarPorta(18);
    }
    public void ativarPorta18(){
        PortaManager.portaManager.AtivarPorta(18);
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
        PortaManager.portaManager.AtivarPorta(17);
    }
    public void next(){
        EvaController.instance.nextMove(true);
    }
}
