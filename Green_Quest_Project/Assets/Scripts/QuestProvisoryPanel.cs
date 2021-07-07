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
        PlayerController.instance.canMove = true;
        QuestManager.questManager.AcceptQuest(questID);
    }

    public void AcceptTheQuestLater(){
        PlayerController.instance.canMove = true;
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }

}
