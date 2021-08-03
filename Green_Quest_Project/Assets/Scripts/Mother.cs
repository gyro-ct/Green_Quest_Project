using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Mother : MonoBehaviour
{
    public bool motherOfAllBools;

    public bool conversaFeita = false;
    public NPCConversation conversation;
    public NPCConversation conversationDefault;
    public int valor = 1;
    public static Mother instance;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        QuestManager.questManager.PrgInstances.Add(gameObject);
    }

    void Update()
    {
        if(motherOfAllBools && Input.GetKeyDown(KeyCode.Space)){
            
            if (QuestManager.questManager.ConversationMainTrigger == 1 &&
            !conversaFeita){
                conversaFeita = true;
                QuestManager.questManager.AddQuestItem("Conversar com Mae", 1);
                PlayerController.instance.C2();
                PlayerController.instance.canInteract = false;
                ConversationManager.Instance.StartConversation(conversation);
            }
            else if (valor == 2){
                ConversationManager.Instance.StartConversation(conversationDefault);
            }
            
        }
    }

    public void ChangeValor(){
        Debug.Log("Valor");
        Mother.instance.valor++;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            Debug.Log("PLAYERMOTHER");
            motherOfAllBools = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if (col.tag == "Player"){
            motherOfAllBools = false;
        }
    }

}
