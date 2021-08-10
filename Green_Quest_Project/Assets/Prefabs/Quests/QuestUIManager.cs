using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestUIManager : MonoBehaviour
{

    public static QuestUIManager uiManager;
    
    public List <Quest> availableQuests = new List<Quest>();
    public List <Quest> activeQuests = new List<Quest>();
    private List<GameObject> qButtons = new List<GameObject>();


    void Awake(){
        if (uiManager == null){
            uiManager = this;
        } else if (uiManager != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Show the Quest Panel on the HUD
    public GameObject qLogButton;
    public GameObject ButtonPanel;
    public Transform qButtonSpacerLogAvailable; //qButton running on qLog

    public void ShowQuestLogPanel(){

        for (int i = 0; i<qButtons.Count; i++){
            Destroy(qButtons[i]);
        }

        qButtons.Clear();

        ButtonPanel.SetActive(true);

        foreach (Quest availableQuest in availableQuests){

            GameObject questButton = Instantiate(qLogButton);
            QLogButton qBScript = questButton.GetComponent<QLogButton>();
            qBScript.questID = availableQuest.id;
            qBScript.questTitle.text = availableQuest.name;
            questButton.transform.SetParent(qButtonSpacerLogAvailable, false);
            questButton.SetActive(true);
            qButtons.Add(questButton);

        }

        foreach (Quest activeQuest in activeQuests){

            GameObject questButton = Instantiate(qLogButton);
            QLogButton qBScript = questButton.GetComponent<QLogButton>();
            qBScript.questID = activeQuest.id;
            qBScript.questTitle.text = activeQuest.name;
            questButton.transform.SetParent(qButtonSpacerLogAvailable, false);
            questButton.SetActive(true);
            qButtons.Add(questButton);

        }

    }

    // Show quest log when the button of the quest is clicked
    public GameObject buttonAceitarQuest;
    public GameObject questDescriptionPanel;
    public TMP_Text questLogTitle;
    public TMP_Text questLogDescription;
    public TMP_Text questLogSummary;
    public TMP_Text questLogHint;

    public void ShowQuestLog(int questID){

        Debug.Log("Showing quest log panel for quest: "+questID);

        questDescriptionPanel.SetActive(true);

        for(int i=0; i<availableQuests.Count; i++){
            if(availableQuests[i].id == questID){

                activateLogPanel(availableQuests[i]);

            }

        }

        for(int i=0; i<activeQuests.Count; i++){
            if(activeQuests[i].id == questID){

                activateLogPanel(activeQuests[i]);

            }

        }

    }

    public void activateLogPanel(Quest activeQuest){

        questLogTitle.text = activeQuest.name;

        if (activeQuest.progress == Quest.QuestProgress.ACCEPTED){

            questLogDescription.text = activeQuest.description;
            questLogSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequirements;
            questLogHint.text = "Dica: " + activeQuest.hint;
            buttonAceitarQuest.SetActive(false);

        } else if(activeQuest.progress == Quest.QuestProgress.AVAILABLE){
            if (activeQuest.staminaUsed <= PlayerController.instance.Stamina){
                questLogDescription.text = activeQuest.description;
                questLogSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequirements;
                questLogHint.text = "Dica: Aperte o botão para começar a quest!";
                buttonAceitarQuest.GetComponent<AcceptQuestNaMochila>().questID = activeQuest.id;
                buttonAceitarQuest.SetActive(true);
            } else {
                questLogDescription.text = "Aumente sua stamina para liberar a quest!, esta quest precisa de " + activeQuest.staminaUsed + " de stamina";
                questLogSummary.text = "";
                questLogHint.text = "Dica: Durma em sua cama para recuperar sua stamina!";
                buttonAceitarQuest.SetActive(false);
            }

        }

    }

    public void HideQuestLogPanel(){

        for (int i = 0; i<qButtons.Count; i++){
            Destroy(qButtons[i]);
        }

        qButtons.Clear();
        ButtonPanel.SetActive(false);
        questDescriptionPanel.SetActive(false);

    }

}
