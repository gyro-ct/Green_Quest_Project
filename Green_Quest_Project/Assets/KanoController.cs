using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class KanoController : MonoBehaviour
{
    public static KanoController instance;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        QuestManager.questManager.PrgInstances.Add(gameObject);
        
    }

    public bool activeTrigger = true;

    public NPCConversation C1;
    public NPCConversation C2;
    public NPCConversation C3;
    public NPCConversation C4;
    public int valor;
    public bool v1 = true;
    public bool v3 = true;
    public bool achouFiltro = false;

    public void ChangeValor(){
        KanoController.instance.valor++;
    }

    public void ativarConversa(){
        if (valor == 1 && v1){
            v1 = false;
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C1);
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
        } else if (valor == 3 && v3){
            v3 = false; // Conversa
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C3);
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(C4);
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
