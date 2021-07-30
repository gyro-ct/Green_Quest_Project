using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class PersulaController : MonoBehaviour
{
    public static PersulaController instance;

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

    public int valor;

    public void ativarConversa(){
        if (valor == 1){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C1);
            valor = 2;
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
        } else if (valor == 3){
            // Não aceito
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C3);
            valor = 2;
        } else if (valor == 4){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C4);
            valor = 5;
        } else if (valor == 5){
            ConversationManager.Instance.StartConversation(C5);
        }
    }

    public bool ativada = false;

    void Update(){
        if (ativada && Input.GetKeyDown(KeyCode.Space)){
            if (valor == 2){
                checarResultado();   
            }
            ativarConversa();
        }
    }

    public void checarResultado(){
        if (!CompComprasManager.instance.EntrouUmaVez){
            valor = 2;
        } else if (CompComprasManager.instance.passouComp){
            valor = 4;
        } else {
            valor = 3;
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
