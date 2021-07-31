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
        QuestManager.questManager.PrgInstances.Add(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public bool ativarXerox = false;

    public NPCConversation C1;
    public NPCConversation CD1;
    public NPCConversation C2;
    public NPCConversation CD2;
    public NPCConversation C3;
    public NPCConversation CDefault;

    public int valor;

    public void ativarConversa(){
        if (valor == 1){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C1);
            valor = 2;
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(CD1);
        } else if (valor == 3){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ativarXerox = true;
            ConversationManager.Instance.StartConversation(C2);
            valor = 4;
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(CD2);
        } else if (valor == 5){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C3);
            valor = 6;
        } else if (valor == 6){
            ConversationManager.Instance.StartConversation(CDefault);
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
