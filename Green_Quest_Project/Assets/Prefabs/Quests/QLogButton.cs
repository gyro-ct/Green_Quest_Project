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
        // QuestUIManager.uiManager.ShowQuestLog(questID);
        QuestManager.questManager.ShowQuestLog(questID);
        GameObject MostrarInformações = GameObject.Find("HUD_Menus(Clone)").transform.Find("CanvasMenus").transform.Find("Mochila").transform.Find("Painel mestre").transform.Find("Tab Quests").transform.Find("QuestCanvas").transform.Find("ItensObject").transform.Find("Panel").transform.Find("QuestDescription").gameObject;
        MostrarInformações.SetActive(true);
    }


}
