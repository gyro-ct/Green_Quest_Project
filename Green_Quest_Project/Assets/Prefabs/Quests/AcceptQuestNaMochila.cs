using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptQuestNaMochila : MonoBehaviour
{
    
    public int questID;

    public void clickIt(){

        QuestManager.questManager.AcceptQuest(questID);
        
    }
}
