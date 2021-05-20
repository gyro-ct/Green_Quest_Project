using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class ComputerUIManager : MonoBehaviour
{

    public static ComputerUIManager computerManager;
    public NPCConversation myConversation;
    public GameObject theBigPanel;
    public GameObject Animation;
    public GameObject MainPanelConversation;

    private bool theBigPanelActive = false;
    public GameObject HUD;

    void Awake(){
        if (computerManager == null){
            computerManager = this;
        } else if (computerManager != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        /*if (Input.GetKeyDown(KeyCode.E)){
            theBigPanelActive = !theBigPanelActive;
            Debug.Log("CLICKe");
            ShowThePanel();
        }*/
    }

    public void ShowThePanel(){
        theBigPanel.SetActive(true);
        HUD = GameObject.Find("HUD_Menus(Clone)").transform.Find("HudGame").gameObject;
        HUD.SetActive(false);
    }

    public void AAAAAAAAAAAAAAAAAAAAAAAAAAA()
    {
        Debug.Log("LOL");
        Animation.SetActive(false);
        MainPanelConversation.SetActive(true);
        Debug.Log("Conversation");
        ConversationManager2.Instance2.StartConversation(myConversation);
        //Debug.Log("ConversationPast");
    }

    
}
