using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{

    // Can call from any other class
    public static QuestManager questManager;

    public bool quest3Trigger = false;
    public bool mother = false;

    public List <Quest> questList = new List<Quest>(); // Lista mestre de quests
    public List <Quest> currentQuestList = new List<Quest>(); // Lista de quests em andamento

    // Inicialização e verificação se não há duplicatas
    void Awake(){
        if(questManager == null){
            questManager = this;
        } else if (questManager != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Funções booleanas
    public bool RequestAvailableQuest(int questID){
        for (int i=0; i<questList.Count; i++){
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE){
                return true;
            }
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID){
        for (int i=0; i<questList.Count; i++){
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED){
                return true;
            }
        }
        return false;
    }

    public bool RequestCompleteQuest(int questID){
        for (int i=0; i<questList.Count; i++){
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.COMPLETED){
                return true;
            }
        }
        return false;
    }

    public bool CheckAvailableQuests(QuestObject NPCQuest){
        for(int i = 0; i<questList.Count; i++){
            for(int j = 0; j<NPCQuest.availableQuestIDs.Count; j++){
                if(questList[i].id == NPCQuest.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE){
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAcceptedQuests(QuestObject NPCQuest){
        for(int i = 0; i<questList.Count; i++){
            for(int j = 0; j<NPCQuest.receivableQuestIDs.Count; j++){
                if(questList[i].id == NPCQuest.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.ACCEPTED){
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCompleteQuests(QuestObject NPCQuest){
        for(int i = 0; i<questList.Count; i++){
            for(int j = 0; j<NPCQuest.receivableQuestIDs.Count; j++){
                if(questList[i].id == NPCQuest.receivableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.COMPLETED){
                    return true;
                }
            }
        }
        return false;
    }

    public void UniqueAddQuestItem(string questObject){
        Debug.Log("lol " + questObject);
        List<Quest> CC = QuestManager.questManager.currentQuestList;
        Debug.Log("BL " + CC.Count);
        for (int i=0; i<CC.Count; i++){
            Debug.Log("lol1 " + CC[i].questObjective);
            if(CC[i].questObjective == questObject && CC[i].progress == Quest.QuestProgress.ACCEPTED){
                CC[i].questObjectiveCount += 1;
            }

            if(CC[i].questObjectiveCount >= CC[i].questObjectiveRequirements && CC[i].progress == Quest.QuestProgress.ACCEPTED){
                CC[i].progress = Quest.QuestProgress.COMPLETED;
                if(CC[i].completeToDone){
                    QuestManager.questManager.CompleteQuest(CC[i].id);
                }
            }
        }
    }

    // Adicionar item objetivo para as quests
    public void AddQuestItem(string questObject, int itemAmount){
        for (int i=0; i<currentQuestList.Count; i++){
            if(currentQuestList[i].questObjective == questObject && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED){
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if(currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirements && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED){
                currentQuestList[i].progress = Quest.QuestProgress.COMPLETED;
                if(currentQuestList[i].completeToDone){
                    CompleteQuest(currentQuestList[i].id);
                }
            }
        }
    }

    public GameObject questProvisoryPanel;
    public GameObject AcceptButton;

    public void ShowQuestProvisoryCanvas(int questID){
        questProvisoryPanel.SetActive(true);
        Debug.Log("ShowIf");
        QuestProvisoryPanel myPanel = questProvisoryPanel.GetComponent<QuestProvisoryPanel>();
        for(int i=0; i<questList.Count; i++){
            if (questList[i].id == questID){
                Debug.Log("ShowIf2");
                for(int j=0; j<currentQuestList.Count;j++){
                    if (currentQuestList[j].id == questID){
                        return;
                    }
                }
                questList[i].progress = Quest.QuestProgress.AVAILABLE;
                currentQuestList.Add(questList[i]);
                QuestUIManager.uiManager.availableQuests.Add(questList[i]);
                myPanel.nome.text = questList[i].name;
                myPanel.desc.text = questList[i].description;
                myPanel.HINT.text = questList[i].hint;
                myPanel.questID = questList[i].id;
                if (questList[i].staminaUsed <= PlayerController.instance.Stamina){
                    AcceptButton.SetActive(true);
                } else {
                    AcceptButton.SetActive(false);
                }
            }
        }
    }

    // Aceitar uma quest (//TODO)
    public void AcceptQuest(int questID){
        Debug.Log("Accept " + questID);
        for(int i=0; i<questList.Count; i++){
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE){
                currentQuestList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;
                QuestUIManager.uiManager.availableQuests.Remove(questList[i]);
                QuestUIManager.uiManager.activeQuests.Add(questList[i]);
                 
                Debug.Log(questList[i].id);
                
                PlayerController.instance.Stamina = PlayerController.instance.Stamina - questList[i].staminaUsed;
                Debug.Log("PS"+PlayerController.instance.Stamina);
                List<GameObject> MyList = ProgressBarManager.ProgressBarInstance.getObjects();
                Debug.Log("PS3"+MyList.Count);
                foreach (GameObject bar in MyList){
                    Slider slider = bar.GetComponent<Slider>();
                    Debug.Log("PS4"+slider.value);
                    float numToSum = -questList[i].staminaUsed;
                    Debug.Log("PS2"+numToSum);
                    //bar.GetComponent<ProgressBar>().IncrementProgress(numToSum);
                    //targetProgress = 
                    bar.GetComponent<ProgressBar>().targetProgress = slider.value + numToSum;
                }
                questList[i].StartQuestTriggers();
            }
        }
    }

    public TMP_Text level;

    // Completar uma quest
    public void CompleteQuest(int questID){
        Debug.Log("alguém me chamou");
        for(int i=0; i<currentQuestList.Count; i++){
            Debug.Log("al " + currentQuestList[i]);
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETED){
                currentQuestList[i].progress = Quest.QuestProgress.DONE;
                currentQuestList[i].EndQuestTriggers();
                currentQuestList.Remove(currentQuestList[i]);
                Debug.Log("al2 " + currentQuestList);

                GameObject MyObj = ProgressBarManager.ProgressBarInstance.getObjectsXP();
                Slider slider = MyObj.GetComponent<Slider>();
                float num = 0f;

                // Passar de level
                if (slider.value + questList[i].expReward >= 100f){
                    PlayerController.instance.Level = PlayerController.instance.Level + 1;
                    level.text = "Level: " + PlayerController.instance.Level.ToString();
                    PlayerController.instance.Experience = (slider.value + questList[i].expReward) - 100f;
                    num = questList[i].expReward - 100f;
                } else {
                    num = questList[i].expReward;
                    PlayerController.instance.Experience = PlayerController.instance.Experience + questList[i].expReward;
                }
                MyObj.GetComponent<ProgressBar>().targetProgress = slider.value + num;

                

                //slider.GetComponent<ProgressBar>().IncrementProgress(num);

                //TODO Canvas Quest quando termina
            }
        }
        Debug.Log(currentQuestList[0].id);
        CheckChainQuest(questID);
    }

    // Ver se há quests em sequência
    void CheckChainQuest(int questID){
        int num = 0;
        for (int i=0; i<questList.Count; i++){
            if(questList[i].id == questID && questList[i].nextQuest > 0){
                num = questList[i].nextQuest;
            }
        }
        if (num > 0){
            for(int i=0; i<questList.Count; i++){
                if (questList[i].id == num && questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE){
                    questList[i].progress = Quest.QuestProgress.ACCEPTED;//AVAILABLE;
                    currentQuestList.Add(questList[i]);
                    //TODO Canvas Quest quando aceita
                    questList[i].StartQuestTriggers();
                }
            }
        }
    }

    // Aceitar uma quest de um NPC (alguma que já esteja disponível)
    public void QuestRequest(QuestObject NPCQuest){
        if(NPCQuest.availableQuestIDs.Count > 0){
            for(int i = 0; i<questList.Count; i++){
                for(int j = 0; j<NPCQuest.availableQuestIDs.Count; j++){
                    if(questList[i].id == NPCQuest.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE){
                        Debug.Log("Quest ID: " + NPCQuest.availableQuestIDs[j] + " " + questList[i].progress);
                        // AcceptQuest(NPCQuest.availableQuestIDs[j]);
                        // UI
                        QuestUIManager.uiManager.questAvailable = true;
                        QuestUIManager.uiManager.availableQuests.Add(questList[i]);
                    }
                }
            }
        }

        for(int i = 0; i<currentQuestList.Count; i++){
            for(int j = 0; j<NPCQuest.receivableQuestIDs.Count; j++){
                if (currentQuestList[i].id == NPCQuest.receivableQuestIDs[j] && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED || currentQuestList[i].progress == Quest.QuestProgress.COMPLETED){
                    Debug.Log("Quest ID: " + NPCQuest.receivableQuestIDs[j] + " " + currentQuestList[i].progress);
                    // CompleteQuest(NPCQuest.receivableQuestIDs[j]);
                    // UI
                    QuestUIManager.uiManager.questRunning = true;
                    QuestUIManager.uiManager.activeQuests.Add(questList[i]);
                }
            }
        }
    }

    public void ShowQuestLog(int questID){
        for(int i=0; i<currentQuestList.Count; i++){
            if(currentQuestList[i].id == questID){
                QuestUIManager.uiManager.ShowQuestLog(currentQuestList[i]);
            }
        }
    }

    public void AtivarAbaItens()
    {
        Debug.Log("Ativou a tab itens!");
        GameObject ActiveItem0 = GameObject.Find("HUD_Menus(Clone)").transform.Find("CanvasMenus").transform.Find("Mochila").transform.Find("Painel mestre").transform.Find("Tab Itens").gameObject;
        ActiveItem0.SetActive(true);
    }

    public void AtivarAviso()
    {
        GameObject ActiveAviso = GameObject.Find("AvisoTabItens").transform.Find("AvisoPanel").gameObject;
        GameObject botao = GameObject.Find("AvisoTabItens").transform.Find("AvisoPanel").transform.Find("Button").gameObject;
        GameObject description1 = GameObject.Find("AvisoTabItens").transform.Find("AvisoPanel").transform.Find("Description1").gameObject;
        GameObject botaotexto = GameObject.Find("AvisoTabItens").transform.Find("AvisoPanel").transform.Find("Button").transform.Find("Text (TMP)").gameObject;
        GameObject description2 = GameObject.Find("AvisoTabItens").transform.Find("AvisoPanel").transform.Find("Description2").gameObject;
        SetColorA(ActiveAviso);
        SetColorA(botao);
        SetColorB(botaotexto);
        SetColorB(description1);
        SetColorB(description2);


    }
    public void SetColorA(GameObject obj)
    {
        Color tmp = obj.GetComponent<Image>().color;
        tmp.a = 255f;
        obj.GetComponent<Image>().color = tmp;
    }
    public void SetColorB(GameObject obj)
    {
        Color tmp = obj.GetComponent<TMP_Text>().color;
        tmp.a = 255f;
        obj.GetComponent<TMP_Text>().color = tmp;
    }

    public void AtivarAreaExit()
    {
        GameObject ActiveExit = GameObject.Find("Area_Exit2").gameObject;
        Debug.Log("Olha ai rapaz " + ActiveExit);
        ActiveExit.SetActive(true);
    }

}
