using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NebeliController : MonoBehaviour
{
    public static NebeliController instance;
    public int count;

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        QuestManager.questManager.PrgInstances.Add(gameObject);
        count = 0;
    }

    public bool isC1Activated = false; // Ativar caixa 1
    public bool isEmpCol1Activated = false; // Ativar collider 1
    public bool isEmpCol2Activated = false; // Ativar collider 2

    public void ativarEmpilhadeira1(){
        NebeliController.instance.isEmpCol1Activated = true;
    }
    public void ativarEmpilhadeira2(){
        isEmpCol1Activated = false;
        isEmpCol2Activated = true;
    }

    public void liberarCaixas(){
        isC1Activated = true;
    }

    public void pegarCaixa(){
        PlayerController.instance.animator.SetBool("EsUmaEmpilhadeira2", true);
    }
    public void soltarCaixa(){
        PlayerController.instance.animator.SetBool("EsUmaEmpilhadeira2", false);
        count++;
        QuestManager.questManager.AddQuestItem("Caixas entregues", 1);
        if(count == 2){
            ativarEmpilhadeira2();
        }
    }

    public NPCConversation C1;
    public NPCConversation C2;
    public NPCConversation C3;
    public NPCConversation C4;

    public int valor = 1;
    public bool v1 = true;
    public bool v3 = true;

    public void ChangeValor(){
        NebeliController.instance.valor++;
    }
    public void ativarConversa(){
        if (valor == 1 && v1){
            v1 = false;
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            QuestManager.questManager.AddQuestItem("Conversar com Nebeli", 1);
            ConversationManager.Instance.StartConversation(C1);
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(C2);
        } else if (valor == 3 && v3){
            v3 = false; //
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            QuestManager.questManager.AddQuestItem("Conversar com Nebeli novamente", 1);
            ConversationManager.Instance.StartConversation(C3);
            PlayerController.instance.endGame = true;
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(C4);
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
