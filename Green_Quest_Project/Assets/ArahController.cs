using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ArahController : MonoBehaviour
{
    public static ArahController instance;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        QuestManager.questManager.PrgInstances.Add(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public bool activeTrigger = true;

    public NPCConversation C1;
    public NPCConversation C2;
    public NPCConversation C3;
    public NPCConversation C4;
    public NPCConversation C5;
    public NPCConversation C6;

    public int valor = 1;

    public void ativarConversa(){
        if (valor == 1){
            PlayerController.instance.canMove = false;
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C1);
            QuestManager.questManager.AddQuestItem("Conversar com diretora", 1);
            valor = 2;
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
        } else if (valor == 3){
            PlayerController.instance.canMove = false;
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C3);
            valor = 4;
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(C4);
        } else if (valor == 5){
            PlayerController.instance.canMove = false;
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C5);
            QuestManager.questManager.AddQuestItem("Falar com diretora produção", 1);
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
