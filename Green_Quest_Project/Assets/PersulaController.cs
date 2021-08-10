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
        DontDestroyOnLoad(gameObject);
        QuestManager.questManager.PrgInstances.Add(gameObject);
    }

    public void ChangeValor(){
        PersulaController.instance.valor++;
    }
    public void ChangeValorToTwo(){
        PersulaController.instance.valor = 2;
        PersulaController.instance.v3 = true;
    }

    public string name = "Persula";

    public bool activeTrigger = true;

    public NPCConversation C1;
    public NPCConversation C2;
    public NPCConversation C3;
    public NPCConversation C4;
    public NPCConversation C5;
    public NPCConversation C6;

    public int valor;
    public bool v1 = true;
    public bool v3 = true;
    public bool v4 = true;

    public void ativarConversa(){
        if (valor == 1 && v1){
            v1 = false; //
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            //ArahController.instance.valor = 7;
            QuestManager.questManager.AddQuestItem("Falar com diretora compras",1);
            ConversationManager.Instance.StartConversation(C1);
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
        } else if (valor == 3 && v3){
            // Não aceito para 2
            v3 = false;
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C3);
        } else if (valor == 4 && v4){
            // Aceito para 5
            v4 = false;
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            QuestManager.questManager.AddQuestItem("Fazer relatório",1);
            ConversationManager.Instance.StartConversation(C4);
        } else if (valor == 5){
            ConversationManager.Instance.StartConversation(C5);
        } else if (valor == 6){
            ConversationManager.Instance.StartConversation(C6);
        }
    }

    public bool ativada = false;

    void Update(){
        if (!activeTrigger){
            for (int i = 0; i<QuestManager.questManager.currentQuestList.Count; i++){
                if (QuestManager.questManager.currentQuestList[i].id == 12){
                    activeTrigger = true;
                }
            }
        }
        if (ativada && Input.GetKeyDown(KeyCode.Space) && activeTrigger){
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
