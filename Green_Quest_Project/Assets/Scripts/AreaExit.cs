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
    private Porte porta;
    public int id;
    
    void Awake(){

        porta = PortaManager.portaManager.listPortas[id-1];
        Debug.Log("DOOR"+porta);

    }

    void Start()
    {
        theEntrance.transitionName = areaTransitionName;

    }

    void Update()
    {
        if(shoudLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shoudLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }

        if(porta.ativarConversaPassiva && Input.GetKeyDown(KeyCode.Space)){
            // Ativar alguma conversa passiva
            Debug.Log("LOLZ");
            ConversationManager.Instance.StartConversation(porta.conversaPassiva);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //SceneManager.LoadScene(areaToLoad);
            if (porta.ativada){
                porta.ativarConversaPassiva = false;
                shoudLoadAfterFade = true;
                UIFade.instance.fadeToBlack();
                PlayerController.instance.areaTransitionName = areaTransitionName;
            } else {
                porta.ativarConversaPassiva = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            porta.ativarConversaPassiva = false;
        }
    }
}
