using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour
{
    public static QuestObject questObject;
    private bool inTrigger = false;

    // Identificador das quests que podem ser oferecidas
    public List<int> availableQuestIDs = new List<int>();

    // Número identificador dos grupos de quests que podem ser ofertadas
    public List<int> receivableQuestIDs = new List<int>();

    public GameObject marker; // canvas
    public Image image;
    public Sprite availableSprite;
    public Sprite receivableSprite;

    void Start(){
        SetQuestMarker();
    }

    /*void Awake(){
        if (questObject == null){
            questObject = this;
        } else if (questObject != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }*/
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            inTrigger = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player"){
            inTrigger = false;
        }
    }

    void Update(){
        if(inTrigger && Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("WORKING");
            //QuestManager.questManager.QuestRequest(this);
            QuestUIManager.uiManager.CheckQuest(this);
        }
        SetQuestMarker();
    } 

    public void SetQuestMarker(){
        // Checa primeiro se há quests completas
        if (QuestManager.questManager.CheckCompleteQuests(this)){
            marker.SetActive(true);
            image.sprite = receivableSprite;
            image.color = Color.yellow;
        } else if (QuestManager.questManager.CheckAvailableQuests(this)){
            marker.SetActive(true);
            image.sprite = availableSprite;
            image.color = Color.yellow;
        } else if (QuestManager.questManager.CheckAcceptedQuests(this)){
            marker.SetActive(true);
            image.sprite = receivableSprite;
            image.color = Color.gray;
        } else {
            marker.SetActive(false);
        }
    }

}
