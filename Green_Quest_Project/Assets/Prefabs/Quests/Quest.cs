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
        Debug.Log("alguém me chamou 2 "+id);
        if (id==1){
            // 3-1-2-1-1-2
            PortaManager.portaManager.AtivarPorta(1);
            QuestManager.questManager.ConversationMainTrigger = 1;
        }
        else if (id == 2){
            QuestManager.questManager.ConversationMainTrigger = 2;
        }
        else if (id == 3){
            QuestManager.questManager.ConversationMainTrigger = 3;
            PortaManager.portaManager.AtivarPorta(2);
        }
        else if (id==4){
            Debug.Log("MEEH");
        }
    }

    public void StartQuestTriggers(){
        Debug.Log("alguém me chamou 2 "+id);
    }

}