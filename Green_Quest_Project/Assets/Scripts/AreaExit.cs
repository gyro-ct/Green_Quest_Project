using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;

[System.Serializable]
public class AreaExit : MonoBehaviour
{
    // Place all references here
    public string areaToLoad;
    public string areaTransitionName;
    public AreaEntrance theEntrance;
    public float waitToLoad = 1f;
    private bool shoudLoadAfterFade;
    private bool boolean1 = false;
    private Porte porta;
    public int id;
    
    void Awake(){

        porta = PortaManager.portaManager.listPortas[id-1];
        Debug.Log("DOOR"+porta);

    }

    void Start()
    {
        Debug.Log("AreaT1: Entrance recebe: " + areaTransitionName);
        theEntrance.transitionName = areaTransitionName;
        boolean1 = false;
    }

    void Update()
    {

        if (shoudLoadAfterFade && Input.GetKeyDown(KeyCode.Space)){
            boolean1 = true;
            UIFade.instance.fadeToBlack();
            Debug.Log("AreaT2: Player recebe: " + areaTransitionName);
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }

        if(boolean1)
        {
                        
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                Debug.Log("AreaT1: Passar cena");
                shoudLoadAfterFade = false;
                boolean1 = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }

        if(porta.ativarConversaPassiva && Input.GetKeyDown(KeyCode.Space) &&
            PlayerController.instance.canInteract){
            // Ativar alguma conversa passiva
            Debug.Log("LOLZ");
            ConversationManager.Instance.StartConversation(porta.conversaPassiva);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("és um player?");
            //SceneManager.LoadScene(areaToLoad);
            if (porta.ativada){
                Debug.Log("és um ativada?");
                porta.ativarConversaPassiva = false;
                shoudLoadAfterFade = true;
            } else {
                porta.ativarConversaPassiva = true;
            }
        }

        else if (other.tag == "Eva"){
            Debug.Log("Keep ma baby");
            if (porta.ativada){
                EvaController.instance.deactivate();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            porta.ativarConversaPassiva = false;
            shoudLoadAfterFade = false;
        }
    }
}
