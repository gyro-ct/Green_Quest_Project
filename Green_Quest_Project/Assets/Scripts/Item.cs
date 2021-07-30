using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DialogueEditor;

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

        if (itemName == "Xícara de Café"){
            Debug.Log("função café");
            
            if (EvaController.instance.PlayerNear){
                Debug.Log("função mensagem333");
                QuestManager.questManager.AddQuestItem("Levar café", 1);
                PortaManager.portaManager.AtivarPorta(11);
                PortaManager.portaManager.AtivarPorta(12);
                for (int i = 0; i < ItemManager.itemmanager.ListItem.Count; i++){
                    if (ItemManager.itemmanager.ListItem[i].itemName == itemName){

                        Debug.Log("item" + ItemManager.itemmanager.ListItem[i].itemName);

                        ItemManager.itemmanager.ListItem.RemoveAt(i);
                        
                        break;
                    }
                }
                EvaController.instance.nextMove(false);
                atvConv.instance.ativarConversa(3);
            }
        }

        if (itemName == "Filtro"){
            if (PlayerController.instance.FiltroAtivado){
                QuestManager.questManager.AddQuestItem("Colocar filtro", 1);

                for (int i = 0; i < ItemManager.itemmanager.ListItem.Count; i++){
                    if (ItemManager.itemmanager.ListItem[i].itemName == itemName){

                        Debug.Log("item" + ItemManager.itemmanager.ListItem[i].itemName);

                        ItemManager.itemmanager.ListItem.RemoveAt(i);
                        
                        break;
                    }
                }
            }

            QuestManager.questManager.desativarFumaca();
            QuestManager.questManager.IsOver = true;
            ArahController.instance.valor = 5;
        }
    }

}
