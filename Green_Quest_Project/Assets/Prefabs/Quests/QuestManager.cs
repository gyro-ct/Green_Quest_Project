using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DialogueEditor;

public class QuestManager : MonoBehaviour
{

    // Can call from any other class
    public static QuestManager questManager;

    public int ConversationMainTrigger = 0;

    public List <Quest> questList = new List<Quest>(); // Lista mestre de quests
    public List <Quest> currentQuestList = new List<Quest>(); // Lista de quests em andamento
    public List <int> currentQuestProvisoryPanelsList = new List<int>(); // Lista de quests em andamento


    // Inicialização e verificação se não há duplicatas
    void Awake(){
        if(questManager == null){
            questManager = this;
        } else if (questManager != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        PrgInstances.RemoveAll( x => !x);
    }

    // Pegar o canvas do item da carta da mãe
    public GameObject CanvasMae;
    public GameObject getCanvasMae(){
        return CanvasMae;
    }

    // Ativar e Desativar o Canvas da fumaça
    public GameObject fumaca;
    public bool IsFActive = false;
    public bool IsOver = false;
    public void ativafumaca(){
        if (!IsOver){
            fumaca.SetActive(true);
            IsFActive = true;
        }
    }
    public void desativarFumaca(){
        if (!IsOver){
            fumaca.SetActive(false);
            IsFActive = false;
        }
    }
    public bool isActive(){
        return IsFActive;
    }

    // Lidar com a lista de instâncias dos personagens
    public List<GameObject> PrgInstances = new List<GameObject>();
    public void deactivatePrg(GameObject maintain){
        for (int i = 0; i<PrgInstances.Count; i++){
            if (PrgInstances[i] != maintain){
                PrgInstances[i].SetActive(false);
            }
        }
        PrgInstances.RemoveAll( x => !x);
        Debug.Log("1: " + PrgInstances);
    }
    public void deactivatePrg2(){
        for (int i = 0; i<PrgInstances.Count; i++){
            PrgInstances[i].SetActive(false);
        }
        PrgInstances.RemoveAll( x => !x);
        Debug.Log("2: " + PrgInstances);
    }

    // MAIN QUEST FUNCTIONS
    public GameObject questProvisoryPanel;
    public GameObject AcceptButton;
    public NPCConversation defaultConversation;

    // Quests go from NOT_AVAILABLE to AVAILABLE only if the player has to accept the quest (main quests) on MakeQuestAvailable
    public void MakeQuestAvailable(int questID){

        Debug.Log("Made available: " + questID);

        for(int i=0; i<questList.Count; i++){

            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE){
                questList[i].progress = Quest.QuestProgress.AVAILABLE;
                QuestUIManager.uiManager.availableQuests.Add(questList[i]);
            }

        }
    }

    // Quests go from NOT_AVAILABLE to ACCEPTED or from AVAILABLE to ACCEPTED on AcceptQuest
    public void AcceptQuest(int questID){

        Debug.Log("Accepted: " + questID);

        questProvisoryPanel.SetActive(false);

        for(int i=0; i<questList.Count; i++){

            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE){

                currentQuestList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;

                QuestUIManager.uiManager.availableQuests.Remove(questList[i]);
                QuestUIManager.uiManager.activeQuests.Add(questList[i]);
                
                PlayerController.instance.Stamina = PlayerController.instance.Stamina - questList[i].staminaUsed;
                List<GameObject> MyList = ProgressBarManager.ProgressBarInstance.getObjects();

                foreach (GameObject bar in MyList){
                    Slider slider = bar.GetComponent<Slider>();
                    float numToSum = -questList[i].staminaUsed;
                    bar.GetComponent<ProgressBar>().targetProgress = slider.value + numToSum;
                }

                if(!PlayerController.instance.canMove){
                    PlayerController.instance.canMove = true;
                    PlayerController.instance.canInteract = true;
                }

                questList[i].StartQuestTriggers();
            }
        }
    }

    // Quests are completed only if the items required are equal to the required amount, done in AddQuestItem
    
    public void AddQuestItem(string questObject, int itemAmount){

        Debug.Log("Added "+itemAmount+" to "+questObject);
        
        for (int i=0; i<currentQuestList.Count; i++){

            if(currentQuestList[i].questObjective == questObject && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED){
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if(currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirements && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED){
                currentQuestList[i].progress = Quest.QuestProgress.COMPLETED;
                CompleteQuest(currentQuestList[i].id);
            }

        }
    }

    // Quest goes from ACCEPTED to COMPLETED only by a call from AddQuestItem using CompleteQuest
    public TMP_Text level;
    public void CompleteQuest(int questID){

        Debug.Log("Completed Quest: " + questID);

        for(int i=0; i<currentQuestList.Count; i++){

            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETED){
                
                currentQuestList[i].progress = Quest.QuestProgress.DONE;
                ConversationMainTrigger++;
                currentQuestList[i].EndQuestTriggers();

                QuestUIManager.uiManager.activeQuests.Remove(currentQuestList[i]);
                currentQuestList.Remove(currentQuestList[i]);

                GameObject MyObj = ProgressBarManager.ProgressBarInstance.getObjectsXP();
                Slider slider = MyObj.GetComponent<Slider>();
                float num = 0f;

                // Pass a level
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

                CheckChainQuest(questID);
            }

        }

    }

    // The next Quest is made available only through CheckChainQuest when called from CompleteQuest
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

                    if (questList[i].completeToDone){
                        questList[i].progress = Quest.QuestProgress.ACCEPTED;
                        currentQuestList.Add(questList[i]);
                        QuestUIManager.uiManager.activeQuests.Add(questList[i]);
                        questList[i].StartQuestTriggers();
                    } else {
                        // Activation by the ShowQuestProvisoryCanvas
                        // questList[i].progress = Quest.QuestProgress.AVAILABLE;
                        // QuestUIManager.uiManager.availableQuests.Add(questList[i]);
                    }
                    
                }

            }
        }

    }

    // Show canvas controlled by the quest manager. Has to be shown when a quest is to be accepted from the panel
    public void ShowQuestProvisoryCanvas(int questID){

        if(!currentQuestProvisoryPanelsList.Contains(questID)){

            currentQuestProvisoryPanelsList.Add(questID);

            PlayerController.instance.canMove = false;
        
            questProvisoryPanel.SetActive(true);
            
            QuestProvisoryPanel myPanel = questProvisoryPanel.GetComponent<QuestProvisoryPanel>();
            
            for(int i=0; i<questList.Count; i++){

                if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.NOT_AVAILABLE){

                    MakeQuestAvailable(questID);

                    myPanel.nome.text = questList[i].name;
                    myPanel.questID = questList[i].id;
                
                    if (questList[i].staminaUsed <= PlayerController.instance.Stamina){
                        AcceptButton.SetActive(true);
                        myPanel.desc.text = questList[i].description;  
                        myPanel.HINT.text = "Dica: " + questList[i].hint;
                    } else {
                        AcceptButton.SetActive(false);
                        myPanel.desc.text = "Aumente sua stamina para liberar a quest!, esta quest precisa de " + questList[i].staminaUsed + " de stamina";
                        // myPanel.HINT.text = questList[i].hint;
                    }
                }

            }

        } else {
            
            for (int i=0; i<questList.Count; i++){
                if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE){
                    ConversationManager.Instance.StartConversation(defaultConversation);
                }
            }
            

        }
    }


    // Other stuff
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
