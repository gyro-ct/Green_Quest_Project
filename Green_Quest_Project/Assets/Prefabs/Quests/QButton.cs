using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QButton : MonoBehaviour
{

    public int questID;
    public Text questTitle;

    // Only prefabs can be instantiated
    private GameObject acceptButton;
    private GameObject completeButton;

    private QButton acceptButtonScript;
    private QButton completeButtonScript;

    void Start(){
        
    }

    void Awake(){
        acceptButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("ButtonContent").transform.Find("AcceptButton").gameObject;
        acceptButtonScript = acceptButton.GetComponent<QButton>();
        acceptButton.SetActive(true);
        acceptButton.SetActive(false);

        completeButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("ButtonContent").transform.Find("CompleteButton").gameObject;
        completeButtonScript = completeButton.GetComponent<QButton>();
        completeButton.SetActive(true);
        completeButton.SetActive(false);
    }

    public void ShowAllInfos(){

        Debug.Log("LY"+completeButton.activeSelf);
        QuestUIManager.uiManager.ShowSelectedQuest(questID);
        Debug.Log("LOL"+questID);
        Debug.Log("LOLAvail"+QuestManager.questManager.RequestAvailableQuest(questID));
        if(QuestManager.questManager.RequestAvailableQuest(questID)){
            acceptButton.SetActive(true);
            Debug.Log("N"+acceptButton.activeSelf);
            acceptButtonScript.questID = questID;
        } else {
            acceptButton.SetActive(false);
        }
        Debug.Log("LOLCompl"+QuestManager.questManager.RequestCompleteQuest(questID));
        if(QuestManager.questManager.RequestCompleteQuest(questID)){
            completeButton.SetActive(true);
            completeButtonScript.questID = questID;
        } else {
            completeButton.SetActive(false);
        }
    }

    public void AcceptQuest(){
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        QuestObject[] currentNPCs = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach(QuestObject obj in currentNPCs){
            obj.SetQuestMarker();
        }
    }

    public void CompleteQuest(){
        QuestManager.questManager.CompleteQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();

        QuestObject[] currentNPCs = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach(QuestObject obj in currentNPCs){
            obj.SetQuestMarker();
        }
    }

    public void ClosePanel(){
        QuestUIManager.uiManager.HideQuestPanel();
    }

}
