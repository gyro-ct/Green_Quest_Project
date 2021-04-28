using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour
{
    
    public Item myItem;

    public void ExecuteItemFunction(){
        Debug.Log("MyFunc Feita");
        myItem.UseButton();
    }

}
