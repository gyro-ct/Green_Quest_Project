using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{   
    public static ItemManager itemmanager;
    public List <Item> ListAllItems = new List<Item>();
    public List <Item> ListItem = new List<Item>();
    private List <GameObject> ListButtons = new List<GameObject>();

    public GameObject button;
    public Transform ButtonPanel;
    public GameObject PanelItem;

    public bool ItemTabAction = false; 

    
    void Awake()
    {
        if(itemmanager == null)
        {
            itemmanager = this;

        }else if (itemmanager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void FillItemButtons ()
    {   
        Debug.Log(ItemTabAction);

        PanelItem.SetActive(true);

        if(!ItemTabAction)
        {
            foreach (Item item in ListItem)
            {
                Debug.Log(item);
                GameObject ItemButton = Instantiate(button);
                ButtonSlot Infobutton = ItemButton.GetComponent<ButtonSlot>();
                Infobutton.nome = item.itemName;
                Infobutton.descricao1 = item.description1;
                Infobutton.descricao2 = item.description2;
                Infobutton.ID = item.value;
                Infobutton.Icone.sprite = item.itemSprite;
                Infobutton.myItem = item;
                Infobutton.Icone.preserveAspect = true;
                ItemButton.transform.SetParent(ButtonPanel,false);
                ListButtons.Add(ItemButton);
            }

            ItemTabAction = true;            

        }

        
    }

    public void hideInformation()
    {
        for (int i = 0; i < ListButtons.Count; i++)
            {
                Destroy(ListButtons[i]);
            }

        ListButtons.Clear();
        ItemTabAction = false;
        PanelItem.SetActive(false);

    }


}
