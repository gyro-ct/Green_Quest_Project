using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public string[] itemsHeld;
    public int[] numberOfItems;
    public Item[] referenceItems;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item GetItemDetails(string itemToGrab)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if(referenceItems[i].nomeDoItem == itemToGrab)
            {
                return referenceItems[i];
            }
        }



        return null;
    }
}
