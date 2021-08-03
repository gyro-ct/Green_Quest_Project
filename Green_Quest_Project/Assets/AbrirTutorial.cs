using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirTutorial : MonoBehaviour
{
    public bool DesTutorial = true;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && DesTutorial)
        {
            TutorialGame.instance.AbrirTutorial(); 
            DesTutorial = false; 
        }
    }
}
