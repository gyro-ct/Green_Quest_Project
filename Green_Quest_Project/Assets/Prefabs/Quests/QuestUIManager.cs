using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Q)){
            questPanelActive = !questPanelActive;
            //Show Log Panel
        }
    }

    public void CheckQuest(QuestObject questObject){
        currentQuestObject = questObject;
        QuestManager.questManager.QuestRequest(questObject);

        if ((questRunning || questAvailable) && !questPanelActive){
            // Show the quest panel
        } else {
            Debug.Log("Nenhuma quest");
        }

    }

    public void ShowQuestPanel(){
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);
        // Fill data
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

}
