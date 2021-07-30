using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class atvConv : MonoBehaviour
{

    public static atvConv instance;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
    }

    public NPCConversation conv1;
    public NPCConversation conv2;
    public NPCConversation conv3;
    public NPCConversation conv4;

    public void ativarConversa(int cnv){
        if (cnv == 1){
            ConversationManager.Instance.StartConversation(conv1);
        } else if (cnv == 2){
            ConversationManager.Instance.StartConversation(conv2);
        } else if (cnv == 3){
            ConversationManager.Instance.StartConversation(conv3);
        } else if (cnv == 4){
            ConversationManager.Instance.StartConversation(conv4);
        }
    }
}
