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
        QuestManager.questManager.PrgInstances.Add(gameObject);
        valor = 1;
        questItem = 0;
        questItem2 = 0;
        ativarConversa();
        DontDestroyOnLoad(gameObject);
    }

    public bool activeTrigger = true;

    // Ela é um NPC, não a Nibila mesmo

    public NPCConversation C1; // Entrada
    public NPCConversation C2; // Caixas fora
    public NPCConversation C3; // Conversa com ela depois das caixas fora -> Trigger ativar caixa
    public NPCConversation C4; // D1
    public NPCConversation C5; // Conversa com ela depois das caixas esvaziadas -> Trigger mover caixa
    public NPCConversation C6; // D2
    public NPCConversation CN1; // Conversa com Sr. Nexus
    public NPCConversation CN2; // D2


    public int valorSrNexus = 1;
    public void ativarConvNexus1(){
        ConversationManager.Instance.StartConversation(CN1);
    }
    public void ativarConvNexus2(){
        ConversationManager.Instance.StartConversation(CN2);
    }

    public void addQuestItem(){
        questItem++;
        Debug.Log("debug " + questItem);
        if (questItem == 4){
            valor = 2;
            ativarConversa();
        }
    }

    public GameObject caixasFalsas;
    public GameObject caixasComCoisas;
    public void ativarcaixa(){
        CaixaEsvaziar.instance.isActivated = true;
    }

    public void addQuest2Item(){
        questItem2++;
        CaixaEsvaziar.instance.isActivated = true;
        if (questItem2 == 4){
            valor = 5;
            CaixaEsvaziar.instance.selfDestroy();
            ativarConversa();
        }
    }



    public void ativarConversa(){
        if (valor == 1){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C1);
        } else if (valor == 2){
            caixasFalsas.SetActive(false);
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C2);
            valor = 3;
        } else if (valor == 3){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C3);
            valor = 4;
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(C4);
        } else if (valor == 5){
            caixasComCoisas.SetActive(false);
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C5);
            valor = 6;
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
