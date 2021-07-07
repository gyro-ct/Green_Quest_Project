using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computador : MonoBehaviour
{
    public bool isTriggered;
    public bool isAccepted = false;

    void Update(){

        if(isTriggered && Input.GetKeyDown(KeyCode.Space) && isAccepted){
            Debug.Log("Wa");
            ComputerUIManager.computerManager.ShowThePanel();
        }
    }

    void FixedUpdate(){
        if(isTriggered){
            for(int i=0; i<QuestManager.questManager.currentQuestList.Count; i++){
                if (QuestManager.questManager.currentQuestList[i].id == 1 && QuestManager.questManager.currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED){
                    //Debug.Log("ISACCEPTED");
                    isAccepted = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Player")
        {
            isTriggered = true;
            if (!isAccepted){
                QuestManager.questManager.ShowQuestProvisoryCanvas(1);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isTriggered = false;
        }
    }
}
