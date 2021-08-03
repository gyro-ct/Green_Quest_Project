using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGame : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject Hud;


    public static TutorialGame instance;
    
    void Awake()
    {
        if (instance == null){
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AbrirTutorial()
    {
        PlayerController.instance.canMove = false;
        tutorial.SetActive(true);
        Hud.SetActive(false);
    }

    public void CanMoveAgain()
    {
        PlayerController.instance.canMove = true;
    }

    public void ShowHudAgain()
    {
        Hud.SetActive(true);
    }
}
