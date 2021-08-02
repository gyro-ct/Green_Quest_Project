using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour
{
    
    public Item myItem;

    public void ExecuteItemFunction(){

        myItem.UseButton();
        
    }

}
