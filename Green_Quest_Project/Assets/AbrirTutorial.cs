using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirTutorial : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && PlayerController.instance.DesTutorial)
        {
            TutorialGame.instance.AbrirTutorial(); 
            PlayerController.instance.DesTutorial = false; 
        }
    }
}
