using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Q101QuizManager : MonoBehaviour
{
    public GameObject Codes;
    public int r1;
    public int r21;
    public int r22;
    public int r23;
    public int r3;
    public int r4;

    public int r;
    public bool FoiContratado;

    public NPCConversation theConv;
    public NPCConversation myConversationGood;
    public NPCConversation myConversationFail;

    public static Q101QuizManager q101;

    void Awake(){

    }
    void Start(){
        if (q101 == null)
        {
            q101 = this;
        } else
        {
            if(q101 != this)
            {
                Destroy(gameObject);
            }
            
        }
        DontDestroyOnLoad(gameObject);
    }

    public void getR(){
        Debug.Log("KKK");
        r1 = ConversationManager.Instance.GetInt("R1");
        Debug.Log("LLL");
        Debug.Log("KKK" + r1);
        r21 = ConversationManager.Instance.GetInt("R21");
        r22 = ConversationManager.Instance.GetInt("R22");
        r23 = ConversationManager.Instance.GetInt("R23");
        r3 = ConversationManager.Instance.GetInt("R3");
        r4 = ConversationManager.Instance.GetInt("R4");
        calcularNota();
    }

    
    public void calcularNota(){
        Debug.Log("Nota");
        r = r1 + r21 + r22 + r23 + r3 + r4;
        Debug.Log(r);
        if (r>=5){
            FoiContratado = true;
        } else {
            FoiContratado = false;
        }
        PlayerController.instance.startCo(20.0f);
    }

    public void Ligacao(){
        
        Debug.Log("Conversa2");
        if (FoiContratado){
            ConversationManager.Instance.StartConversation(myConversationGood);
        } else {
            ConversationManager.Instance.StartConversation(myConversationFail);
        }
    }

}
