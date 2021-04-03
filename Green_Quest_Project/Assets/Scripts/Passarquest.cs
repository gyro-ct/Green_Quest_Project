using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passarquest : MonoBehaviour     
{

    public QuestObject questObject;

    public void AssignNPC (QuestObject NPC)
    {
        questObject = NPC ;
    }

    public void passarAQuest(int questID)
    {
        questObject.availableQuestIDs.Add(questID);
    }

    public void checarQuests(QuestObject NPC)
    {
        QuestUIManager.uiManager.CheckQuest(NPC);

    }




}
