using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Item 
{
    
    [Header("Item Details")]
    public string itemName;
    
    public string description1;
    public string description2;
    public int value;
    public Sprite itemSprite;

    public GameObject Player;
    public GameObject Menu;
    public GameObject BotaoCloseMochila;


    public GameObject CanvasCartaMae;

    public void UseButton(){
        if (itemName == "Vara de Pesca"){
            Debug.Log("função vara de pesca");
            if(PlayerController.instance.GotFish){
                Debug.Log("Pesca permitida");
                Player = GameObject.Find("Player(Clone)").gameObject;
                Menu = GameObject.Find("MenuJogador").transform.Find("CanvasMenus").transform.Find("Mochila").gameObject;
                BotaoCloseMochila = GameObject.Find("MenuJogador").transform.Find("ButtonCloseMochila").gameObject;
                //Player.SetActive(false);
                Color tmp = Player.GetComponent<SpriteRenderer>().color;
                tmp.a = 0f;
                Player.GetComponent<SpriteRenderer>().color = tmp;
                Menu.SetActive(false);
                BotaoCloseMochila.SetActive(false);
                SceneManager.LoadScene("Fishing2");
            } else {
                Debug.Log("Não há peixes por aqui");
            }
        }

        if (itemName == "Mensagem de sua mãe"){
            Debug.Log("função mensagem");

            if (QuestManager.questManager.ConversationMainTrigger == 2){
                Debug.Log("função mensagem222");
                QuestManager.questManager.AddQuestItem("Ler Carta", 1);
            }

            CanvasCartaMae = QuestManager.questManager.getCanvasMae();
            CanvasCartaMae.SetActive(true);
        }
    }

}
