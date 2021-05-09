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

    public GameObject painelConv;

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

    void Update(){
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
        encerrar();
        calcularNota();
    }

    public void encerrar(){
        Debug.Log("KKKKKKKKKKKKKKKKKKkkk");
        painelConv = GameObject.Find("UIComputer").transform.Find("ConversationPanel").transform.Find("SairConversa").gameObject;
        painelConv.SetActive(true);
    }

    public void calcularNota(){
        Debug.Log("Nota");
        r = r1 + r21 + r22 + r23 + r3 + r4;
        //Debug.Log("RR" + r);
        if (r>=5){
            FoiContratado = true;
            Debug.Log("FC "+ FoiContratado);
        } else {
            FoiContratado = false;
        }
        PlayerController.instance.startCo(2.0f);
        Debug.Log("FC3 "+ FoiContratado);
        
        Ligacao();
    }

    public void Ligacao(){
        Debug.Log("FC2 "+ FoiContratado);
        if (FoiContratado){
            Debug.Log("Conversa2");
            QuestManager.questManager.AddQuestItem("MexerNoComputador", 1);
            QuestManager.questManager.CompleteQuest(1);
            ConversationManager.Instance.StartConversation(myConversationGood);
        } else {
            Debug.Log("Conversa3");
            ConversationManager.Instance.StartConversation(myConversationFail);
        }
    }

}
