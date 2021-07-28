using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MarkerQuestTrigger
{
    public bool isEnabled = false;
    public int markerid;

    public void showQuestMarker(GameObject gameObject){
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void hideQuestMarker(GameObject gameObject){
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
