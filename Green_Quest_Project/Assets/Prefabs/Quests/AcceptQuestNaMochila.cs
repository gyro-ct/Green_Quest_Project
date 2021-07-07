using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptQuestNaMochila : MonoBehaviour
{
    
    public int questID;

    public void clickIt(){
        Debug.Log("Accept " + questID);
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.ShowQuestLogPanel();
        
    }
}
