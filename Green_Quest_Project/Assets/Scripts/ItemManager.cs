using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{   
    public Transform ButtonPanel;
 
    public static ItemManager itemmanager;

    public List <Item> ListItem = new List<Item>();

    public GameObject button;

    public bool ItemTabAction = false; 

    private List <GameObject> ListButtons = new List<GameObject>();

    
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

    
    void Update()
    {
        
    }

    public void FillItemButtons ()
    {   
        Debug.Log(ItemTabAction);
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

        if(ItemTabAction)
        {
            for (int i = 0; i < ListButtons.Count; i++)
            {
                Destroy(ListButtons[i]);
            }

            ListButtons.Clear();
            ItemTabAction = false;
        }

    }

    

}
