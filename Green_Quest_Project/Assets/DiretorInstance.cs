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
        DontDestroyOnLoad(gameObject);
        QuestManager.questManager.PrgInstances.Add(gameObject);
    }

    public string name = "Diretor";

    public bool activeTrigger = true;

    public NPCConversation C1;
    public NPCConversation C2;

    public int valor;

    public void ChangeValor(){
        DiretorInstance.instance.valor++;
    }

    public bool v1 = true;

    public void ativarConversa(){
        if (valor == 1 && v1){
            v1 = false;
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            QuestManager.questManager.AddQuestItem("Falar com diretor", 1);
            ConversationManager.Instance.StartConversation(C1);
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
        }
    }

    public bool ativada = false;

    void Update(){
        if (!activeTrigger){
            for (int i = 0; i<QuestManager.questManager.currentQuestList.Count; i++){
                if (QuestManager.questManager.currentQuestList[i].id == 11){
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
