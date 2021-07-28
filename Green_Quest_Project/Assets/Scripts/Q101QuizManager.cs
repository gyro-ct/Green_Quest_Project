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
    public bool FoiContratado = false;

    public bool TriggerforDormir = false;

    public NPCConversation myConversationGood;
    public NPCConversation myConversationFail;

    public GameObject painelConv;

    public static Q101QuizManager q101;

    void Awake(){

    }
    void Start(){
        Debug.Log("START AGAIN");
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
        // DontDestroyOnLoad(gameObject);
    }

    void Update(){
    }

    public void getR(){
        Debug.Log("KKK");
        r1 = ConversationManager2.Instance2.GetInt("R1");
        Debug.Log("LLL");
        Debug.Log("KKK" + r1);
        r21 = ConversationManager2.Instance2.GetInt("R21");
        r22 = ConversationManager2.Instance2.GetInt("R22");
        r23 = ConversationManager2.Instance2.GetInt("R23");
        r3 = ConversationManager2.Instance2.GetInt("R3");
        r4 = ConversationManager2.Instance2.GetInt("R4");
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
        Debug.Log("RR" + r);
        if (r>=5){
            FoiContratado = true;
            Debug.Log("FC "+ FoiContratado);
        } else {
            FoiContratado = false;
        }
        Debug.Log("FC3 "+ FoiContratado);
        PlayerController.instance.FoiContratado = FoiContratado;
    }

    public void Ligacao(){
        Debug.Log("FC2 "+ FoiContratado + " " + r);
        TriggerforDormir = true;
        StartCoroutine(EC(5.0f));
    }

    IEnumerator EC(float time)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        Ligacao2();
    }

    public void Ligacao2(){
        Debug.Log("FC2AAAAAAAAAAA");

        if (PlayerController.instance.FoiContratado){
            Debug.Log("Conversa2");
            QuestManager.questManager.AddQuestItem("Mexer no Computador", 1);
            QuestManager.questManager.CompleteQuest(1);
            ConversationManager.Instance.StartConversation(myConversationGood);
        } else {
            Debug.Log("Conversa3");
            ConversationManager.Instance.StartConversation(myConversationFail);
        }
    }

}
