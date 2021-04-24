using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class LigarButton : MonoBehaviour
{
    public Conv conversa;
    private int callID;
    private int contID;

    public void FazerLigacao(){
        ConversationManager.Instance.StartConversation(conversa.Conversa);
    }

    public void SetVar1(int var1){callID = var1;}
    public void SetVar2(int var2){contID = var2;
    DummyCall();}
    public void DummyCall(){
        ConvManager.convManager.ActivateReceiveCallCanvas(callID, contID);
    }

}