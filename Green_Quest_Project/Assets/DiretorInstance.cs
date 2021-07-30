using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DiretorInstance : MonoBehaviour
{
    public static DiretorInstance instance;

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

    public int valor;

    public void aumentarValor(){
        valor = valor+1;
    }

    public void ativarConversa(){
        if (valor == 1){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C1);
            valor = 2;
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
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
