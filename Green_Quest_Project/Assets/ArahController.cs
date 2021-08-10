using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ArahController : MonoBehaviour
{
    public static ArahController instance;
    public bool activeTrigger = false;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        QuestManager.questManager.PrgInstances.Add(gameObject);
        activeTrigger = false;
        
    }
    public string name = "Arah";

    public NPCConversation C1;
    public NPCConversation C2;
    public NPCConversation C3;
    public NPCConversation C4;
    public NPCConversation C5;
    public NPCConversation C6;
    public NPCConversation C7;

    public int valor = 1;

    public bool v1 = true;
    public bool v3 = true;
    public bool v5 = true;

    public void ativarConversa(){
        if (valor == 1 && v1){
            v1 = false; // Change Valor
            PlayerController.instance.canMove = false;
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C1);
            EvaController.instance.valor = 6;
            QuestManager.questManager.AddQuestItem("Conversar com diretora", 1);
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
        } else if (valor == 3 && v3){
            v3 = false; // Change Valor
            PlayerController.instance.canMove = false;
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C3);
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(C4);
        } else if (valor == 5 && v5){
            v5 = false; // Change Valor
            PlayerController.instance.canMove = false;
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C5);
            QuestManager.questManager.AddQuestItem("Falar com diretora produção", 1);
        } else if (valor == 6){
            ConversationManager.Instance.StartConversation(C6);
        } else if (valor == 7){
            ConversationManager.Instance.StartConversation(C7);
        }
    }

    public bool ativada = false;

    public void ChangeValor(){
        ArahController.instance.valor++;
    }

    void Update(){
        if (!activeTrigger){
            for (int i = 0; i<QuestManager.questManager.currentQuestList.Count; i++){
                if (QuestManager.questManager.currentQuestList[i].id == 7){
                    activeTrigger = true;
                }
            }
        }
        if (ativada && Input.GetKeyDown(KeyCode.Space) && activeTrigger){
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
