using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NibilaController : MonoBehaviour
{
    public static NibilaController instance;

    public int valor = 1;
    public int questItem;
    public int questItem2;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        QuestManager.questManager.PrgInstances.Add(gameObject);
        //ativarConversa();
    }

    void Start(){
        valor = 1;
        questItem = 0;
        questItem2 = 0;
    }

    public bool activeTrigger = true;
    public bool achouRelogio = false;

    // Ela é um NPC, não a Nibila mesmo

    public NPCConversation C1; // Entrada
    public NPCConversation C2; // Caixas fora
    public NPCConversation C3; // Conversa com ela depois das caixas fora -> Trigger ativar caixa
    public NPCConversation C4; // D1
    public NPCConversation C5; // Conversa com ela depois das caixas esvaziadas -> Trigger mover caixa
    public NPCConversation C6; // D2
    public NPCConversation CN1; // Conversa com Sr. Nexus
    public NPCConversation CN2; // D2

    public bool vn1 = true;
    public bool vn2 = true;

    public void ReturnVN2(){
        NibilaController.instance.vn2 = true;
    }
    public int valorSrNexus = 1;

    public void ChangeNexusValor(){
        NibilaController.instance.valorSrNexus++;
    }
    public void ativarConvNexus1(){
        ConversationManager.Instance.StartConversation(CN1);
    }
    public void ativarConvNexus2(){
        ConversationManager.Instance.StartConversation(CN2);
    }

    public GameObject caixasFalsas;
    public GameObject caixasFalsas2;
    public GameObject caixasComCoisas;
    public bool oneTimer = true;
    public void addQuestItem(){
        questItem++;
        Debug.Log("debug " + questItem);
        if (questItem == 4){
            valor = 2;
            //GameObject.Find("CaixasFalsas").gameObject.SetActive(false);
            caixasFalsas2 = GameObject.Find("CaixasFalsas").gameObject;
            caixasFalsas2.SetActive(false);
            QuestManager.questManager.AddQuestItem("Arrastar caixas", 1);
            ativarConversa();
        }
    }

    public void ativarcaixa(){
        CaixaEsvaziar.instance.isActivated = true;
    }

    public void addQuest2Item(){
        questItem2++;
        CaixaEsvaziar.instance.isActivated = true;
        if (questItem2 == 4){
            valor = 5;
            QuestManager.questManager.AddQuestItem("Levar 4 papéis", 1);
            CaixaEsvaziar.instance.selfDestroy();
            ativarConversa();
        }
    }

    public void ChangeValor(){
        NibilaController.instance.valor++;
    }

    public bool v1 = true;
    public bool v2 = true;
    public bool v3 = true;
    public bool v5 = true;
    public void ativarConversa(){
        if (valor == 1 && v1){
            v1 = false;
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            QuestManager.questManager.AddQuestItem("Conversar com Pessoa", 1);
            ConversationManager.Instance.StartConversation(C1);
        } else if (valor == 2 && v2){
            v2 = false;
            caixasFalsas.SetActive(false);
            PlayerController.instance.C2(); //
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C2);
        } else if (valor == 3 && v3){
            v3 = false;
            PlayerController.instance.C2(); //
            PlayerController.instance.canInteract = false;
            QuestManager.questManager.AddQuestItem("Conversar com Pessoa novamente", 1);
            ConversationManager.Instance.StartConversation(C3);
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(C4);
        } else if (valor == 5 && v5){
            v5 = false; //
            caixasComCoisas.SetActive(false);
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C5);
        } else if (valor == 6){
            ConversationManager.Instance.StartConversation(C6);
        }
    }

    public bool ativada = false;

    void Update(){
        if (ativada && Input.GetKeyDown(KeyCode.Space)){
            ativarConversa();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            ativada = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            ativada = false;
        }
    }
}
