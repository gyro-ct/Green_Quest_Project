using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUIManager : MonoBehaviour
{

    public static ComputerUIManager computerManager;
    
    public GameObject theBigPanel;

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
}
