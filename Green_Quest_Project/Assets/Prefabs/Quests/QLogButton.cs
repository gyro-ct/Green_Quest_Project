using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QLogButton : MonoBehaviour
{

    public int questID;
    public TMP_Text questTitle;

    public void ShowAllInfos(){
        
        QuestUIManager.uiManager.ShowQuestLog(questID);

    }


}
