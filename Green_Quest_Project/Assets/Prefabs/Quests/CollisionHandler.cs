using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("PASSED");
        QuestManager.questManager.AddQuestItem("Leave Town 1", 1);
    }
}
