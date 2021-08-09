using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class LigarButton : MonoBehaviour
{
    public Conv conversa;
    public int callID;
    public int contID;

    public void FazerLigacao(){
        ConversationManager.Instance.StartConversation(conversa.Conversa);
    }

    public void Call(){
        ConvManager.convManager.ActivateReceiveCallCanvas(callID, contID);
    }

}