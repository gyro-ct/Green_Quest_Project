using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestUIManager : MonoBehaviour
{

    public static QuestUIManager uiManager;
    
    // Booleanas
    public bool questAvailable = false;
    public bool questRunning = false;
    private bool questPanelActive = false;
    private bool questLogPanelActive = false;

    // Painels
    public GameObject questPanel;
    public GameObject questLogPanel;

    // Objetos de quest
    private QuestObject currentQuestObject;

    // Lista de quests
    public List <Quest> availableQuests = new List<Quest>();
    public List <Quest> activeQuests = new List<Quest>();

    // Botões
    public GameObject qButton;
    public GameObject qLogButton;
    private List<GameObject> qButtons = new List<GameObject>();
    private GameObject acceptButton;
    private GameObject completeButton; 

    // Spacer [Contents of Buttons] (Vertical and Horizontal Layout)
    public Transform qButtonSpacerAvailable; //qButton available
    public Transform qButtonSpacerRunning; //qButton running
    public Transform qButtonSpacerLogAvailable; //qButton running on qLog

    // Textos
    public Text questTitle;
    public Text questDescription;
    public Text questSummary;

    public Text questLogTitle;
    public Text questLogDescription;
    public Text questLogSummary;

    void Awake(){
        if (uiManager == null){
            uiManager = this;
        } else if (uiManager != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        HideQuestPanel();
    }

    void Update(){
        /*if (Input.GetKeyDown(KeyCode.Q)){
            questLogPanelActive = !questLogPanelActive;
            ShowQuestLogPanel();
        }*/

    }

    public void CheckQuest(QuestObject questObject){
        currentQuestObject = questObject;
        QuestManager.questManager.QuestRequest(questObject);

        if ((questRunning || questAvailable) && !questPanelActive){
            ShowQuestPanel();
        } else {
            Debug.Log("Nenhuma quest");
        }

    }

    public void ShowQuestPanel(){
        Debug.Log("Entrou no Show");
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);
        FillQuestButtons();
    }

    public void ShowQuestLogPanel(){
        //questLogPanel.SetActive(questLogPanelActive);
        questLogPanelActive = true;
        questLogPanel.SetActive(true);
        if (questLogPanelActive && !questPanelActive){
            foreach(Quest curQuest in QuestManager.questManager.currentQuestList){
                GameObject questButton = Instantiate(qLogButton);
                QLogButton qblutton = questButton.GetComponent<QLogButton>();

                Debug.Log("I"+curQuest.id+" "+curQuest.name);

                qblutton.questID = curQuest.id;
                qblutton.questTitle.text = curQuest.name;

                questButton.transform.SetParent(qButtonSpacerLogAvailable, false);
                qButtons.Add(questButton);
            }
        } else if(!questLogPanelActive && !questPanelActive){
            HideQuestLogPanel();
        }
    }

    public void ShowQuestLog(Quest activeQuest){
        questLogTitle.text = activeQuest.name;
        if (activeQuest.progress == Quest.QuestProgress.ACCEPTED){
            questLogDescription.text = activeQuest.hint;
            questLogSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequirements;
        } else if(activeQuest.progress == Quest.QuestProgress.COMPLETED){
            questLogDescription.text = activeQuest.congratulation;
            questLogSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequirements;
        }
    }

    public void HideQuestPanel(){
        questPanelActive = false;
        questAvailable = false;
        questRunning = false;

        questTitle.text = "";
        questDescription.text = "";
        questSummary.text = "";

        availableQuests.Clear();
        activeQuests.Clear();

        for (int i=0; i<qButtons.Count;i++){
            Destroy(qButtons[i]);
        }
        qButtons.Clear();
        questPanel.SetActive(questPanelActive);
    }

    public void HideQuestLogPanel(){
        questLogPanelActive = false;

        questLogTitle.text = "";
        questLogDescription.text = "";
        questLogSummary.text = "";

        for (int i = 0; i<qButtons.Count; i++){
            Destroy(qButtons[i]);
        }
        qButtons.Clear();
        questLogPanel.SetActive(questLogPanelActive);
    }

    void FillQuestButtons(){
        foreach (Quest availableQuest in availableQuests){
            GameObject questButton = Instantiate(qButton);
            QButton qBScript = questButton.GetComponent<QButton>();
            qBScript.questID = availableQuest.id;
            qBScript.questTitle.text = availableQuest.name;
            questButton.transform.SetParent(qButtonSpacerAvailable, false);
            qButtons.Add(questButton);
        }

        foreach (Quest activeQuest in activeQuests){
            GameObject questButton = Instantiate(qButton);
            QButton qBScript = questButton.GetComponent<QButton>();
            qBScript.questID = activeQuest.id;
            qBScript.questTitle.text = activeQuest.name;
            questButton.transform.SetParent(qButtonSpacerRunning, false);
            qButtons.Add(questButton);
        }
    }

    // Mostrar informações das Quests

    public void ShowSelectedQuest(int questID){
        for (int i=0; i<availableQuests.Count; i++){
            if(availableQuests[i].id == questID){
                questTitle.text = availableQuests[i].name;
                Debug.Log(availableQuests[i].progress);
                if(availableQuests[i].progress == Quest.QuestProgress.AVAILABLE){
                    questDescription.text = availableQuests[i].description;
                    // Podemos mudar essa mensagem!
                    questSummary.text = availableQuests[i].questObjective + " : " + availableQuests[i].questObjectiveCount + " / " + availableQuests[i].questObjectiveRequirements;
                }
            }
        }

        for (int i=0; i<activeQuests.Count; i++){
            Debug.Log("HEY" + i);
            if(activeQuests[i].id == questID){
                questTitle.text = activeQuests[i].name;
                Debug.Log(activeQuests[i].progress);
                if(activeQuests[i].progress == Quest.QuestProgress.ACCEPTED){
                    questDescription.text = activeQuests[i].hint;
                    // Podemos mudar essa mensagem!
                    questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + " / " + activeQuests[i].questObjectiveRequirements;
                } else if (activeQuests[i].progress == Quest.QuestProgress.COMPLETED){
                    questDescription.text = activeQuests[i].congratulation;
                    questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + " / " + activeQuests[i].questObjectiveRequirements;
                }
            }
        }
    }

}
