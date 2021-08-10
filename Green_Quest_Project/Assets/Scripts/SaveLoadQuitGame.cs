using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class SaveLoadQuitGame : MonoBehaviour
{
    public static SaveLoadQuitGame saveLoadQuitGame;
    void Awake(){
        if(saveLoadQuitGame == null){
            saveLoadQuitGame = this;
        } else if (saveLoadQuitGame != this){
            Destroy(gameObject);
        }
    }


    public void Save()
    {
        Save s = new Save();

        SaveGameScene(s);

        SaveGame(s);
    }

    
    public void SaveGame(Save s)
    {
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Save", JsonConvert.SerializeObject(s)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
        Debug.Log("Game Salvo!");

    }
    void OnDataSend(UpdateUserDataResult result){
        Debug.Log("Data sent successfuly");
    }

    public void LoadGame()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }
    void OnDataReceived(GetUserDataResult result){
        Debug.Log("Received user data");
        if (result.Data != null && result.Data.ContainsKey("Save")){
            Save l = JsonConvert.DeserializeObject<Save>(result.Data["Save"].Value);

            LoadGameScene(l);

            Debug.Log("Game loaded!");
        } else {
            Debug.Log("Player data not complete");
        }
    }
    
    void OnError(PlayFabError error){
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public GameObject Arah;
    public GameObject Brenes;
    public GameObject Diretor;
    public GameObject Eva;
    public GameObject Kano;
    public GameObject Nebeli;
    public GameObject Nibila;
    public GameObject Persula;
    public GameObject _Mother;

    public void LoadGameScene(Save s){

        SceneManager.LoadScene(s.SavingScene);
        PlayerController.instance.transform.position = new Vector3(s.position[0], s.position[1], s.position[2]);

        for (int i=0; i<QuestManager.questManager.questList.Count;i++){
            if (s.availableQuests.Contains(QuestManager.questManager.questList[i].id)){
                QuestManager.questManager.questList[i].progress = Quest.QuestProgress.AVAILABLE;
                QuestUIManager.uiManager.availableQuests.Add(QuestManager.questManager.questList[i]);
            }
            if (s.activeQuests.Contains(QuestManager.questManager.questList[i].id)){
                QuestManager.questManager.questList[i].progress = Quest.QuestProgress.ACCEPTED;
                QuestUIManager.uiManager.activeQuests.Add(QuestManager.questManager.questList[i]);
            }
            if (s.currentQuestList.Contains(QuestManager.questManager.questList[i].id)){
                QuestManager.questManager.questList[i].progress = Quest.QuestProgress.ACCEPTED;
                QuestManager.questManager.currentQuestList.Add(QuestManager.questManager.questList[i]);
            }
            if (s.currntQuestProvCanvas.Contains(QuestManager.questManager.questList[i].id)){
                QuestManager.questManager.currentQuestProvisoryPanelsList.Add(QuestManager.questManager.questList[i].id);
            }
        }

        for (int i=0; i<ItemManager.itemmanager.ListAllItems.Count;i++){
            if(s.inventory.Contains(ItemManager.itemmanager.ListAllItems[i].value)){
                ItemManager.itemmanager.ListItem.Add(ItemManager.itemmanager.ListAllItems[i]);
            }
        }

        for (int i=0; i<ConvManager.convManager.contList.Count;i++){
            if (s.conversas.Contains(ConvManager.convManager.contList[i].ID)){
                ConvManager.convManager.contListActive.Add(ConvManager.convManager.contList[i]);
            }
        }

        QuestManager.questManager.ConversationMainTrigger = s.convMainTrigger;
        QuestManager.questManager.IsFActive = s.questManagerBools[0];
        QuestManager.questManager.IsOver = s.questManagerBools[1];

        for (int i=0; i<PortaManager.portaManager.listPortas.Count;i++){
            if (s.activeDoors.Contains(PortaManager.portaManager.listPortas[i].id)){
                PortaManager.portaManager.listPortas[i].ativada = true;
            }
        }

        for (int i=0; i<NoticiaManager.noticiaManager.allNoticiaList.Count;i++){
            if (s.availableNoticias.Contains(NoticiaManager.noticiaManager.allNoticiaList[i].ID)){
                NoticiaManager.noticiaManager.availableNoticiaList.Add(NoticiaManager.noticiaManager.allNoticiaList[i]);
            }
            if (s.readNoticias.Contains(NoticiaManager.noticiaManager.allNoticiaList[i].ID)){
                NoticiaManager.noticiaManager.readNoticiaList.Add(NoticiaManager.noticiaManager.allNoticiaList[i]);
            }
        }

        for (int i=0; i<EmailManager.emailManager.allEmailList.Count;i++){
            if (s.availableEmails.Contains(EmailManager.emailManager.allEmailList[i].ID)){
                EmailManager.emailManager.availableEmailList.Add(EmailManager.emailManager.allEmailList[i]);
            }
            if (s.readEmails.Contains(EmailManager.emailManager.allEmailList[i].ID)){
                EmailManager.emailManager.readEmailList.Add(EmailManager.emailManager.allEmailList[i]);
            }
        }

        PlayerController.instance.moveSpeed = (float)s.PlayerAndCharacterValues["PC_moveSpeed"];
        PlayerController.instance.Stamina = (float)s.PlayerAndCharacterValues["PC_Stamina"];
        PlayerController.instance.Experience = (float)s.PlayerAndCharacterValues["PC_Experience"];
        PlayerController.instance.Level = s.PlayerAndCharacterValues["PC_Level"];
        PlayerController.instance.lastHorizontal = (float)s.PlayerAndCharacterValues["PC_lastHorizontal"];
        PlayerController.instance.lastVertical = (float)s.PlayerAndCharacterValues["PC_lastVertical"];

        PlayerController.instance.canMove = s.PlayerAndCharacterBools["PC_canMove"];
        PlayerController.instance.canInteract = s.PlayerAndCharacterBools["PC_canInteract"];
        PlayerController.instance.FoiContratado = s.PlayerAndCharacterBools["PC_FoiContratado"];
        PlayerController.instance.FiltroAtivado = s.PlayerAndCharacterBools["PC_FiltroAtivado"];
        PlayerController.instance.conversaComEva = s.PlayerAndCharacterBools["PC_conversaComEva"];
        PlayerController.instance.endGame = s.PlayerAndCharacterBools["PC_endGame"];
        PlayerController.instance.mybool = s.PlayerAndCharacterBools["PC_mybool"];
        PlayerController.instance.DesTutorial = s.PlayerAndCharacterBools["PC_DesTutorial"];
        PlayerController.instance.YAbool = s.PlayerAndCharacterBools["PC_YAbool"];
        PlayerController.instance.YAbool1 = s.PlayerAndCharacterBools["PC_YAbool1"];

        foreach (string name in s.activeInstances){
            Debug.Log("1: " + name);
            if (name == "Arah"){
                Instantiate(Arah);
                //QuestManager.questManager.PrgInstances.Add(Arah);
                ArahController.instance.valor = s.PlayerAndCharacterValues["AR_valor"];
                ArahController.instance.activeTrigger = s.PlayerAndCharacterBools["AR_activeTrigger"];
                ArahController.instance.v1 = s.PlayerAndCharacterBools["AR_v1"];
                ArahController.instance.v3 = s.PlayerAndCharacterBools["AR_v3"];
                ArahController.instance.v5 = s.PlayerAndCharacterBools["AR_v5"];
            }
            else if (name == "Sr. Brenes"){
                Instantiate(Brenes);
                //QuestManager.questManager.PrgInstances.Add(Brenes);
                BrenesController.instance.valor = s.PlayerAndCharacterValues["BR_valor"];
                BrenesController.instance.activeTrigger = s.PlayerAndCharacterBools["BR_activeTrigger"];
                BrenesController.instance.ativarXerox = s.PlayerAndCharacterBools["BR_ativarXerox"];
                BrenesController.instance.foundReport = s.PlayerAndCharacterBools["BR_foundReport"];
                BrenesController.instance.v1 = s.PlayerAndCharacterBools["BR_v1"];
                BrenesController.instance.v3 = s.PlayerAndCharacterBools["BR_v3"];
                BrenesController.instance.v5 = s.PlayerAndCharacterBools["BR_v5"];
            }
            else if (name == "Sr. Diretor"){
                Instantiate(Diretor);
                //QuestManager.questManager.PrgInstances.Add(Diretor);
                DiretorInstance.instance.valor = s.PlayerAndCharacterValues["DR_valor"];
                DiretorInstance.instance.activeTrigger = s.PlayerAndCharacterBools["DR_activeTrigger"];
                DiretorInstance.instance.v1 = s.PlayerAndCharacterBools["DR_v1"];
            }
            else if (name == "Eva"){
                Instantiate(Eva);
                //QuestManager.questManager.PrgInstances.Add(Eva);
                EvaController.instance.modeWalk = s.PlayerAndCharacterValues["EV_modeWalk"];
                EvaController.instance.walking = s.PlayerAndCharacterValues["EV_walking"];
                EvaController.instance.smoothTime = (float)s.PlayerAndCharacterValues["EV_smoothTime"];
                EvaController.instance.sortingOrder = s.PlayerAndCharacterValues["EV_sortingLayer"];
                EvaController.instance.valor = s.PlayerAndCharacterValues["EV_valor"];
                EvaController.instance.start = s.PlayerAndCharacterBools["EV_start"];
                EvaController.instance.passouFase5 = s.PlayerAndCharacterBools["EV_passouFase5"];
                EvaController.instance.active31 = s.PlayerAndCharacterBools["EV_active31"];
                EvaController.instance.active32 = s.PlayerAndCharacterBools["EV_active32"];
                EvaController.instance.active33 = s.PlayerAndCharacterBools["EV_active33"];
                EvaController.instance.coffeMachineActivated = s.PlayerAndCharacterBools["EV_coffeMachineActivated"];
                EvaController.instance.isColliderActive = s.PlayerAndCharacterBools["EV_isColliderActive"];
                EvaController.instance.isOnSGA = s.PlayerAndCharacterBools["EV_isOnSGA"];
                EvaController.instance.oneActivation = s.PlayerAndCharacterBools["EV_oneActivation"];
                EvaController.instance.v2 = s.PlayerAndCharacterBools["EV_v2"];
                EvaController.instance.v4 = s.PlayerAndCharacterBools["EV_v4"];
            }
            else if (name == "Sr.Kano"){
                Instantiate(Kano);
                //QuestManager.questManager.PrgInstances.Add(Kano);
                KanoController.instance.valor = s.PlayerAndCharacterValues["KA_valor"];
                KanoController.instance.activeTrigger = s.PlayerAndCharacterBools["KA_activeTrigger"];
                KanoController.instance.v1 = s.PlayerAndCharacterBools["KA_v1"];
                KanoController.instance.v3 = s.PlayerAndCharacterBools["KA_v3"];
                KanoController.instance.achouFiltro = s.PlayerAndCharacterBools["KA_achouFiltro"];
            }
            else if (name == "Nebeli"){
                Instantiate(Nebeli);
                //QuestManager.questManager.PrgInstances.Add(Nebeli);
                NebeliController.instance.valor = s.PlayerAndCharacterValues["NE_valor"];
                NebeliController.instance.count = s.PlayerAndCharacterValues["NE_count"];
                NebeliController.instance.activeTrigger = s.PlayerAndCharacterBools["NE_activeTrigger"];
                NebeliController.instance.isC1Activated = s.PlayerAndCharacterBools["NE_isC1Activated"];
                NebeliController.instance.isEmpCol1Activated = s.PlayerAndCharacterBools["NE_isEmpCol1Activated"];
                NebeliController.instance.isEmpCol2Activated = s.PlayerAndCharacterBools["NE_isEmpCol2Activated"];
                NebeliController.instance.v1 = s.PlayerAndCharacterBools["NE_v1"];
                NebeliController.instance.v3 = s.PlayerAndCharacterBools["NE_v3"];
            }
            else if (name == "Nibila"){
                Instantiate(Nibila);
                //QuestManager.questManager.PrgInstances.Add(Nibila);
                NibilaController.instance.valor = s.PlayerAndCharacterValues["NI_valor"];
                NibilaController.instance.valorSrNexus = s.PlayerAndCharacterValues["NI_valorSrNexus"];
                NibilaController.instance.questItem = s.PlayerAndCharacterValues["NI_questItem"];
                NibilaController.instance.questItem2 = s.PlayerAndCharacterValues["NI_questItem2"];
                NibilaController.instance.activeTrigger = s.PlayerAndCharacterBools["NI_activeTrigger"];
                NibilaController.instance.achouRelogio = s.PlayerAndCharacterBools["NI_achouRelogio"];
                NibilaController.instance.vn1 = s.PlayerAndCharacterBools["NI_vn1"];
                NibilaController.instance.vn2 = s.PlayerAndCharacterBools["NI_vn2"];
                NibilaController.instance.v1 = s.PlayerAndCharacterBools["NI_v1"];
                NibilaController.instance.v2 = s.PlayerAndCharacterBools["NI_v2"];
                NibilaController.instance.v3 = s.PlayerAndCharacterBools["NI_v3"];
                NibilaController.instance.v5 = s.PlayerAndCharacterBools["NI_v5"];
                NibilaController.instance.oneTimer = s.PlayerAndCharacterBools["NI_oneTimer"];
            }
            else if (name == "Persula"){
                Instantiate(Persula);
                //QuestManager.questManager.PrgInstances.Add(Persula);
                PersulaController.instance.valor = s.PlayerAndCharacterValues["PE_valor"];
                PersulaController.instance.activeTrigger = s.PlayerAndCharacterBools["PE_activeTrigger"];
                PersulaController.instance.v1 = s.PlayerAndCharacterBools["PE_v1"];
                PersulaController.instance.v3 = s.PlayerAndCharacterBools["PE_v3"];
                PersulaController.instance.v4 = s.PlayerAndCharacterBools["PE_v4"];
            }
            else if (name == "Mother"){
                Instantiate(_Mother);
                //QuestManager.questManager.PrgInstances.Add(_Mother);
                Mother.instance.valor = s.PlayerAndCharacterValues["MO_valor"];
                Mother.instance.conversaFeita = s.PlayerAndCharacterBools["MO_conversaFeita"];
                Mother.instance.foundMomLetter = s.PlayerAndCharacterBools["MO_foundMomLetter"];
            }
        }

        if (s.SavingScene == "CompanySGARoom"){sceneVerification("corredor_SGA", "SGA");}
        else if (s.SavingScene == "CompanyReceptionScene"){sceneVerification("corredor_recepcao", "recepcao");}
        else if (s.SavingScene == "CompanyLogisticScene"){sceneVerification("corredor_logistica", "logistica");}
        else if (s.SavingScene == "CompanyComunicacaoMarketingScene"){sceneVerification("corredor_comunicacao", "comunicacao");}
        else if (s.SavingScene == "CoffeeScene"){sceneVerification("corredor_coffee", "coffee");}
        
    }

    private Dictionary<string, int> mainIntDict = new Dictionary<string, int>();
    private Dictionary<string, bool> mainBoolDict = new Dictionary<string, bool>();
    public void SaveGameScene(Save s){

        // Initialization
        mainIntDict = new Dictionary<string, int>();
        mainBoolDict = new Dictionary<string, bool>();

        s.SavingScene = SceneManager.GetActiveScene().name;
        s.position = new List<float> {PlayerController.instance.transform.position.x,
                                      PlayerController.instance.transform.position.y,
                                      PlayerController.instance.transform.position.z};
        
        for (int i=0; i<QuestUIManager.uiManager.availableQuests.Count;i++){
            s.availableQuests.Add(QuestUIManager.uiManager.availableQuests[i].id);
        }
        for (int i=0; i<QuestUIManager.uiManager.activeQuests.Count;i++){
            s.activeQuests.Add(QuestUIManager.uiManager.activeQuests[i].id);
        }

        for (int i=0; i<ItemManager.itemmanager.ListItem.Count;i++){
            s.inventory.Add(ItemManager.itemmanager.ListItem[i].value);
        }

        for (int i=0; i<ConvManager.convManager.contListActive.Count;i++){
            s.conversas.Add(ConvManager.convManager.contListActive[i].ID);
        }

        s.convMainTrigger = QuestManager.questManager.ConversationMainTrigger;
        s.questManagerBools = new List<bool> {QuestManager.questManager.IsFActive,
                                              QuestManager.questManager.IsOver};
        for (int i=0; i<QuestManager.questManager.currentQuestList.Count;i++){
            s.currentQuestList.Add(QuestManager.questManager.currentQuestList[i].id);
        }
        for (int i=0; i<QuestManager.questManager.currentQuestProvisoryPanelsList.Count;i++){
            s.currntQuestProvCanvas.Add(QuestManager.questManager.currentQuestProvisoryPanelsList[i]);
        }

        for (int i=0; i<PortaManager.portaManager.listPortas.Count;i++){
            if (PortaManager.portaManager.listPortas[i].ativada){
                s.activeDoors.Add(PortaManager.portaManager.listPortas[i].id);
            }
        }

        for (int i=0; i<NoticiaManager.noticiaManager.availableNoticiaList.Count;i++){
            s.availableNoticias.Add(NoticiaManager.noticiaManager.availableNoticiaList[i].ID);
        }
        for (int i=0; i<NoticiaManager.noticiaManager.readNoticiaList.Count;i++){
            s.readNoticias.Add(NoticiaManager.noticiaManager.readNoticiaList[i].ID);
        }

        for (int i=0; i<EmailManager.emailManager.availableEmailList.Count;i++){
            s.availableEmails.Add(EmailManager.emailManager.availableEmailList[i].ID);
        }
        for (int i=0; i<EmailManager.emailManager.readEmailList.Count;i++){
            s.readEmails.Add(EmailManager.emailManager.readEmailList[i].ID);
        }

        mainIntDict.Add("PC_moveSpeed", (int)PlayerController.instance.moveSpeed);
        mainIntDict.Add("PC_Stamina", (int)PlayerController.instance.Stamina);
        mainIntDict.Add("PC_Experience", (int)PlayerController.instance.Experience);
        mainIntDict.Add("PC_Level", (int)PlayerController.instance.Level);
        mainIntDict.Add("PC_lastHorizontal", (int)PlayerController.instance.lastHorizontal);
        mainIntDict.Add("PC_lastVertical", (int)PlayerController.instance.lastVertical);

        mainBoolDict.Add("PC_canMove", PlayerController.instance.canMove);
        mainBoolDict.Add("PC_canInteract",PlayerController.instance.canInteract);
        mainBoolDict.Add("PC_FoiContratado",PlayerController.instance.FoiContratado);
        mainBoolDict.Add("PC_FiltroAtivado",PlayerController.instance.FiltroAtivado);
        mainBoolDict.Add("PC_conversaComEva",PlayerController.instance.conversaComEva);
        mainBoolDict.Add("PC_endGame",PlayerController.instance.endGame);
        mainBoolDict.Add("PC_mybool",PlayerController.instance.mybool);
        mainBoolDict.Add("PC_DesTutorial",PlayerController.instance.DesTutorial);
        mainBoolDict.Add("PC_YAbool",PlayerController.instance.YAbool);
        mainBoolDict.Add("PC_YAbool1",PlayerController.instance.YAbool1);

        foreach (GameObject inst in QuestManager.questManager.PrgInstances){
            s.activeInstances.Add(inst.name);
            if (inst.name == "Arah"){
                mainIntDict.Add("AR_valor", (int)ArahController.instance.valor);
                mainBoolDict.Add("AR_activeTrigger", ArahController.instance.activeTrigger);
                mainBoolDict.Add("AR_v1", ArahController.instance.v1);
                mainBoolDict.Add("AR_v3", ArahController.instance.v3);
                mainBoolDict.Add("AR_v5", ArahController.instance.v5);
            }
            else if (inst.name == "Sr. Brenes"){
                mainIntDict.Add("BR_valor", (int)BrenesController.instance.valor);
                mainBoolDict.Add("BR_activeTrigger", BrenesController.instance.activeTrigger);
                mainBoolDict.Add("BR_ativarXerox", BrenesController.instance.ativarXerox);
                mainBoolDict.Add("BR_foundReport", BrenesController.instance.foundReport);
                mainBoolDict.Add("BR_v1", BrenesController.instance.v1);
                mainBoolDict.Add("BR_v3", BrenesController.instance.v3);
                mainBoolDict.Add("BR_v5", BrenesController.instance.v5);
            }
            else if (inst.name == "Sr. Diretor"){
                mainIntDict.Add("DR_valor", (int)DiretorInstance.instance.valor);
                mainBoolDict.Add("DR_activeTrigger", DiretorInstance.instance.activeTrigger);
                mainBoolDict.Add("DR_v1", DiretorInstance.instance.v1);
            }
            else if (inst.name == "Eva"){
                mainIntDict.Add("EV_modeWalk", (int)EvaController.instance.modeWalk);
                mainIntDict.Add("EV_walking", (int)EvaController.instance.walking);
                mainIntDict.Add("EV_smoothTime", (int)EvaController.instance.smoothTime);
                mainIntDict.Add("EV_sortingLayer", (int)EvaController.instance.sortingOrder);
                mainIntDict.Add("EV_valor", (int)EvaController.instance.valor);
                mainBoolDict.Add("EV_start", EvaController.instance.start);
                mainBoolDict.Add("EV_passouFase5", EvaController.instance.passouFase5);
                mainBoolDict.Add("EV_active31", EvaController.instance.active31);
                mainBoolDict.Add("EV_active32", EvaController.instance.active32);
                mainBoolDict.Add("EV_active33", EvaController.instance.active33);
                mainBoolDict.Add("EV_coffeMachineActivated", EvaController.instance.coffeMachineActivated);
                mainBoolDict.Add("EV_isColliderActive", EvaController.instance.isColliderActive);
                mainBoolDict.Add("EV_isOnSGA", EvaController.instance.isOnSGA);
                mainBoolDict.Add("EV_oneActivation", EvaController.instance.oneActivation);
                mainBoolDict.Add("EV_v2", EvaController.instance.v2);
                mainBoolDict.Add("EV_v4", EvaController.instance.v4);
            }
            else if (inst.name == "Sr.Kano"){
                mainIntDict.Add("KA_valor", (int)KanoController.instance.valor);
                mainBoolDict.Add("KA_activeTrigger", KanoController.instance.activeTrigger);
                mainBoolDict.Add("KA_v1", KanoController.instance.v1);
                mainBoolDict.Add("KA_v3", KanoController.instance.v3);
                mainBoolDict.Add("KA_achouFiltro", KanoController.instance.achouFiltro);
            }
            else if (inst.name == "Nebeli"){
                mainIntDict.Add("NE_valor", (int)NebeliController.instance.valor);
                mainIntDict.Add("NE_count", (int)NebeliController.instance.count);
                mainBoolDict.Add("NE_activeTrigger", NebeliController.instance.activeTrigger);
                mainBoolDict.Add("NE_isC1Activated", NebeliController.instance.isC1Activated);
                mainBoolDict.Add("NE_isEmpCol1Activated", NebeliController.instance.isEmpCol1Activated);
                mainBoolDict.Add("NE_isEmpCol2Activated", NebeliController.instance.isEmpCol2Activated);
                mainBoolDict.Add("NE_v1", NebeliController.instance.v1);
                mainBoolDict.Add("NE_v3", NebeliController.instance.v3);
            }
            else if (inst.name == "Nibila"){
                mainIntDict.Add("NI_valor", (int)NibilaController.instance.valor);
                mainIntDict.Add("NI_valorSrNexus", (int)NibilaController.instance.valorSrNexus);
                mainIntDict.Add("NI_questItem", (int)NibilaController.instance.questItem);
                mainIntDict.Add("NI_questItem2", (int)NibilaController.instance.questItem2);
                mainBoolDict.Add("NI_activeTrigger", NibilaController.instance.activeTrigger);
                mainBoolDict.Add("NI_achouRelogio", NibilaController.instance.achouRelogio);
                mainBoolDict.Add("NI_vn1", NibilaController.instance.vn1);
                mainBoolDict.Add("NI_vn2", NibilaController.instance.vn2);
                mainBoolDict.Add("NI_v1", NibilaController.instance.v1);
                mainBoolDict.Add("NI_v2", NibilaController.instance.v2);
                mainBoolDict.Add("NI_v3", NibilaController.instance.v3);
                mainBoolDict.Add("NI_v5", NibilaController.instance.v5);
                mainBoolDict.Add("NI_oneTimer", NibilaController.instance.oneTimer);
            }
            else if (inst.name == "Persula"){
                mainIntDict.Add("PE_valor", (int)PersulaController.instance.valor);
                mainBoolDict.Add("PE_activeTrigger", PersulaController.instance.activeTrigger);
                mainBoolDict.Add("PE_v1", PersulaController.instance.v1);
                mainBoolDict.Add("PE_v3", PersulaController.instance.v3);
                mainBoolDict.Add("PE_v4", PersulaController.instance.v4);
            }
            else if (inst.name == "Mother"){
                mainIntDict.Add("MO_valor", (int)Mother.instance.valor);
                mainBoolDict.Add("MO_conversaFeita", Mother.instance.conversaFeita);
                mainBoolDict.Add("MO_foundMomLetter", Mother.instance.foundMomLetter);
            }
        }

        s.PlayerAndCharacterValues = mainIntDict;
        s.PlayerAndCharacterBools = mainBoolDict;

    }

    public void sceneVerification(string transitionName, string direction){

        // If para caixas da área de comunicação e marketing
        if (direction == "comunicacao"){
            if (NibilaController.instance.achouRelogio){
                GameObject.Find("itemtest pickup (4)").gameObject.SetActive(false);
            }
            for (int i = 0; i<QuestManager.questManager.questList.Count; i++){
                if(QuestManager.questManager.questList[i].id == 15 &&
                    QuestManager.questManager.questList[i].progress == Quest.QuestProgress.DONE){
                    GameObject.Find("Caixa1").gameObject.SetActive(false);
                    GameObject.Find("Caixa2").gameObject.SetActive(false);
                    GameObject.Find("Caixa3").gameObject.SetActive(false);
                    GameObject.Find("Caixa4").gameObject.SetActive(false);
                    GameObject.Find("CaixasFalsas").gameObject.SetActive(false);
                }
                if(QuestManager.questManager.questList[i].id == 17 &&
                    QuestManager.questManager.questList[i].progress == Quest.QuestProgress.DONE){
                    GameObject.Find("CaixasParaEsvaziar").gameObject.SetActive(false);
                }
            }
        }

        // If para caixas da área logística
        if (direction == "logistica"){
            for (int i = 0; i<QuestManager.questManager.questList.Count; i++){
                if(QuestManager.questManager.questList[i].id == 25 &&
                    QuestManager.questManager.questList[i].progress == Quest.QuestProgress.DONE){
                    GameObject.Find("Caixas iterativas Amarela").gameObject.SetActive(false);
                    GameObject.Find("Caixas iterativas Roxa").gameObject.SetActive(false);
                }
            }
        }

        // Ifs para os personagens

        // Eva
        else if ((transitionName == "corredor_SGA") && (direction == "SGA")){
            EvaController.instance.gameObject.SetActive(true);
            if (EvaController.instance.isOnSGA){
                EvaController.instance.modeWalk = 28;
                EvaController.instance.walking = 0;
                EvaController.instance.toAE(2);
            }
            QuestManager.questManager.deactivatePrg(EvaController.instance.gameObject);
        } else if ((transitionName == "cidade_recepcao") && (direction == "recepcao")){
            for (int i=0; i<QuestManager.questManager.currentQuestList.Count; i++){
                if (QuestManager.questManager.currentQuestList[i].id == 4){
                    EvaController.instance.gameObject.SetActive(true);
                }
            }
            QuestManager.questManager.deactivatePrg(EvaController.instance.gameObject);
        } else if ((transitionName == "corredor_recepcao") && (direction == "corredor")){
            for (int i=0; i<QuestManager.questManager.currentQuestList.Count; i++){
                if (QuestManager.questManager.currentQuestList[i].id == 5 && !EvaController.instance.isOnSGA){
                    EvaController.instance.modeWalk = 2;
                    EvaController.instance.walking = 0;
                    EvaController.instance.toAE(1);
                    EvaController.instance.gameObject.SetActive(true);
                }
            }
            QuestManager.questManager.deactivatePrg(EvaController.instance.gameObject);
        }
        // Logística - Nebeli
        else if ((transitionName == "corredor_logistica" || transitionName == "logistica_garden") && (direction == "logistica")){
            NebeliController.instance.gameObject.SetActive(true);
            QuestManager.questManager.deactivatePrg(NebeliController.instance.gameObject);
        }
        // Comunicação e Marketing - Pessoa [Não é o Sr. Nexus]
        else if (transitionName == "corredor_comunicacao" && direction == "comunicacao"){
            NibilaController.instance.gameObject.SetActive(true);
            QuestManager.questManager.deactivatePrg(NibilaController.instance.gameObject);
        }
        else {
            QuestManager.questManager.deactivatePrg2();
        }
    }

}
