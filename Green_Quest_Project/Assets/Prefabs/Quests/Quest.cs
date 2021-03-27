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
    public string done_message; // Mensagem quando completa
    public int nextQuest; // Identificação da próxima quest (se houver)

    public string questObjective; // Objetivo da quest [5 ouro]
    public int questObjectiveCount; // Quantidade coletada do objetivo [3 ouro]
    public int questObjectiveRequirements; // Quantidade de objetivos necessária [5 ouro]

    public int expReward;
    public int staminaUsed;

}