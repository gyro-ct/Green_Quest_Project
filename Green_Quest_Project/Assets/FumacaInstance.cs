using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumacaInstance : MonoBehaviour
{
    public bool IsActive = false;

    public bool isActive(){
        return IsActive;
    }

    public void desativarFumaca(){
        gameObject.SetActive(false);
        IsActive = false;
    }

    public void ativarFumaca(){
        gameObject.SetActive(true);
        IsActive = true;
    }
}
