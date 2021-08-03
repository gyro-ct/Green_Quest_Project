using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderQuest : MonoBehaviour
{
    public bool active = false;
    public bool onceActive = true;
    public int questID;
    void Update()
    {
        if (active && onceActive){
            onceActive = false;
            QuestManager.questManager.ShowQuestProvisoryCanvas(questID);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            active = false;
        }
    }
}
