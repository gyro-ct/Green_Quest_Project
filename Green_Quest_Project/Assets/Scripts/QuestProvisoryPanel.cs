using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestProvisoryPanel : MonoBehaviour
{
    public TMP_Text nome;
    public TMP_Text desc;
    public TMP_Text HINT;
    //public Button Accept;
    //public Button AcceptAfter;
    public int questID;
    
    public void AcceptTheQuest(){
        QuestManager.questManager.AcceptQuest(questID);
        Destroy(gameObject);
    }

    public void AcceptTheQuestLater(){
        Destroy(gameObject);
    }

}
