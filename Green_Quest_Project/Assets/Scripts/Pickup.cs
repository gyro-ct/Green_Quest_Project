using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private Item Thisitem;

    [Header("Item Details")]
    public string NomeDoItem;
    public int IDDoItem;
    public Sprite ImagemDoItem;
    public string Descrição1;
    [UnityEngine.TextArea]
    public string Descrição2;
    
    private bool IsAccepted;


    private void Start()
    {
        Thisitem = new Item();
        IsAccepted = true;
        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //Debug.Log(inventory);
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrou");
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            if (NomeDoItem == "Mensagem de sua mãe" && 
            QuestManager.questManager.ConversationMainTrigger < 2){
                Debug.Log("Não Passou");
                IsAccepted = false;
            } else {
                IsAccepted = true;
            }


            if (IsAccepted){
                Thisitem.itemName = NomeDoItem;
                Thisitem.description1 = Descrição1;
                Thisitem.description2 = Descrição2;
                Thisitem.value = IDDoItem;
                Thisitem.itemSprite = ImagemDoItem;
                ItemManager.itemmanager.ListItem.Add(Thisitem);
                if (NomeDoItem == "Relógio do Sr. Kano"){
                    NibilaController.instance.achouRelogio = true;
                } else if (NomeDoItem == "Filtro"){
                    KanoController.instance.achouFiltro = true;
                    KanoController.instance.valor = 2;
                    QuestManager.questManager.AddQuestItem("Achar filtro G3", 1);
                    ArahController.instance.valor = 3;
                } else if (NomeDoItem == "Relatório ambiental"){
                    BrenesController.instance.foundReport = true;
                }
                Destroy(gameObject);
            }
            

        }
    }
}
