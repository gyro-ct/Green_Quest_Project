using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingVideo : MonoBehaviour
{
    public GameObject TheEndingVideo;
    public GameObject VideoPlayer;

    public bool isActive = false;
    private void Update() {
        if (isActive && PlayerController.instance.endGame && Input.GetKeyDown(KeyCode.Space)){
            QuestManager.questManager.AddQuestItem("Porta aberta", 1);
            TheEndingVideo.SetActive(true);
            VideoPlayer.SetActive(true);
            PlayerController.instance.C3();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            isActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            isActive = false;
        }
    }
}
