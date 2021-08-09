using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Comportamentos que todas as classes tem
[System.Serializable]
public class Quest
{
    public enum QuestProgress
    {
        NOT_AVAILABLE,
        AVAILABLE,
        ACCEPTED,
        COMPLETED,
        DONE
    }

    public string name; // Nome da quest
    public int id; // Identificação da quest
    public QuestProgress progress; // Progresso da quest [ver enum]
    [TextArea]
    public string description; // Descrição da quest
    public string hint; // Hint quando quest está sendo feita
    public string congratulation; // Mensagem quando completa
    public int nextQuest; // Identificação da próxima quest (se houver)

    public string questObjective; // Objetivo da quest [5 ouro]
    public int questObjectiveCount; // Quantidade coletada do objetivo [3 ouro]
    public int questObjectiveRequirements; // Quantidade de objetivos necessária [5 ouro]

    public float expReward;
    public float staminaUsed;
    public bool completeToDone;

    public void EndQuestTriggers(){
        if (id==1){
            // 3-1-2-1-1-2
            PortaManager.portaManager.AtivarPorta(1);
            ConvManager.convManager.addContact(1);
        }else if (id == 2){
        }
        else if (id == 3){
            PortaManager.portaManager.AtivarPorta(2);
            PortaManager.portaManager.AtivarPorta(3);
            EmailManager.emailManager.addEmail(2);
            EmailManager.emailManager.addEmail(3);
            ConvManager.convManager.addContact(8);
        }
        else if (id == 4){}
        else if (id == 5){}
        else if (id == 6){
            EmailManager.emailManager.addEmail(4);
            NoticiaManager.noticiaManager.addNoticia(2);
            ConvManager.convManager.addContact(7);
        }
        else if (id == 7){
            ConvManager.convManager.addContact(6);
        }
        else if (id == 8){}
        else if (id == 9){}
        else if (id == 10){
            EmailManager.emailManager.addEmail(5);
        }
        else if (id == 11){
            EmailManager.emailManager.addEmail(6);
            ConvManager.convManager.addContact(2);
        }
        else if (id == 12){
            ConvManager.convManager.addContact(4);
        }
        else if (id == 13){
            Debug.Log("Quest 13 special Log");
            PortaManager.portaManager.AtivarPorta(18);
            EmailManager.emailManager.addEmail(7);
            NoticiaManager.noticiaManager.addNoticia(3);
        }
        else if (id == 14){
            ConvManager.convManager.addContact(5);
        }
        else if (id == 15){}
        else if (id == 16){}
        else if (id == 17){}
        else if (id == 18){
            EmailManager.emailManager.addEmail(8);
        }
        else if (id == 19){
            NoticiaManager.noticiaManager.addNoticia(4);
        }
        else if (id == 20){}
        else if (id == 21){}
        else if (id == 22){
            EmailManager.emailManager.addEmail(9);
            NoticiaManager.noticiaManager.addNoticia(5);
        }
        else if (id == 23){
            ConvManager.convManager.addContact(3);
        }
        else if (id == 24){}
        else if (id == 25){}
        else if (id == 26){}
        else if (id == 27){
            EmailManager.emailManager.addEmail(10);
        }
        else if (id == 28){}
    }

    public void StartQuestTriggers(){
    }

}