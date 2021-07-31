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
        QuestManager.questManager.PrgInstances.Add(gameObject);
        count = 0;
        DontDestroyOnLoad(gameObject);
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
        if(count == 2){
            ativarEmpilhadeira2();
        }
    }

    public NPCConversation C1;
    public NPCConversation CD1;
    public NPCConversation C2;
    public NPCConversation CDefault;

    public int valor = 1;

    public void ativarConversa(){
        if (valor == 1){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C1);
        } else if (valor == 2){
            ConversationManager.Instance.StartConversation(CD1);
        } else if (valor == 3){
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            ConversationManager.Instance.StartConversation(C2);
            valor = 4;
        } else if (valor == 4){
            ConversationManager.Instance.StartConversation(CDefault);
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
