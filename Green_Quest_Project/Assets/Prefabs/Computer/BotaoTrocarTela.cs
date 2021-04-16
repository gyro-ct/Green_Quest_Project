using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoTrocarTela : MonoBehaviour
{
    public GameObject thePanel;
    public GameObject theContactPanel;
    public GameObject theBigPanel;
    public string TAG;

    /*void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            theBigPanelActive = !theBigPanelActive;
            ShowThePanel();
        }
    }

    public void ShowThePanel(){
        theBigPanelActive = true;
        theBigPanel.SetActive(theBigPanelActive);
    }*/

    public void TrocarTela(){
        if (TAG == "Folder"){
            thePanel.SetActive(true);
        } else if (TAG == "Contact"){
            Debug.Log("CONTACT");
            theContactPanel.SetActive(true);
        }
        
    }

    public void Close(){
        if (TAG == "Folder"){
            thePanel.SetActive(false);
        } else if (TAG == "Contact"){
            theContactPanel.SetActive(false);
        }
    }

    public void CloseAll(){
        Debug.Log("CLOSE");

        thePanel.SetActive(false);
        theContactPanel.SetActive(false);
        theBigPanel.SetActive(false);
    }

    
}
