using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoTrocarTela : MonoBehaviour
{
    public GameObject thePanel;
    public GameObject theBigPanel;

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
        thePanel.SetActive(true);
    }

    public void Close(){
        thePanel.SetActive(false);
    }

    public void CloseAll(){
        Debug.Log("CLOSE");
        thePanel.SetActive(false);
        theBigPanel.SetActive(false);
    }
}
