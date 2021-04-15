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

    void Awake(){
        Debug.Log("AWAKE");
        if (computerManager == null){
            computerManager = this;
        } else if (computerManager != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            theBigPanelActive = !theBigPanelActive;
            Debug.Log("CLICKe");
            ShowThePanel();
        }
    }

    public void ShowThePanel(){
        theBigPanel.SetActive(theBigPanelActive);
    }

    public void AAAAAAAAAAAAAAAAAAAAAAAAAAA()
    {

        Debug.Log("LOL");
        Animation.SetActive(false);
        MainPanelConversation.SetActive(true);
        Debug.Log("Conversation");
        ConversationManager.Instance.StartConversation(myConversation);
        Debug.Log("ConversationPast");
    }
}
