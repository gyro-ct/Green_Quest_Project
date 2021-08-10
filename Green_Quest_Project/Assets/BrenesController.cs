using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class BrenesController : MonoBehaviour
{
    public static BrenesController instance;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        QuestManager.questManager.PrgInstances.Add(gameObject);
        
    }

    public string name = "Brenes";

    public bool ativarXerox = false;
    public bool activeTrigger = false;
    public bool foundReport = false;

    public NPCConversation C1;
    public NPCConversation C2;
    public NPCConversation C3;
    public NPCConversation C4;
    public NPCConversation C5;
    public NPCConversation C6;

    public int valor;
    public bool v1 = true;
    public bool v3 = true;
    public bool v5 = true;

    public void ChangeValor(){
        BrenesController.instance.valor++;
    }

    public void ativarConversa(){
        if (valor == 1 && v1){
            v1 = false; //
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            QuestManager.questManager.AddQuestItem("Conversar com o Sr. Brenes", 1);
            ConversationManager.Instance.StartConversation(C1);
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
        } else if (valor == 3 && v3){
            v3 = false; //
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ativarXerox = true;
            ConversationManager.Instance.StartConversation(C3);
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(C4);
        } else if (valor == 5 && v5){
            v5 = false; //
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C5);
        } else if (valor == 6){
            ConversationManager.Instance.StartConversation(C6);
        }
    }

    public bool ativada = false;

    void Update(){
        if (!activeTrigger){
            for (int i = 0; i<QuestManager.questManager.currentQuestList.Count; i++){
                if (QuestManager.questManager.currentQuestList[i].id == 19){
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
