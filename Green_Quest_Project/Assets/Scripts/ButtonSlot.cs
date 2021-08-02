using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ButtonSlot : MonoBehaviour
{
    public TMP_Text Nome;
    public TMP_Text Descricao1;
    public TMP_Text Descricao2;
    public Image Icone;
    public int ID;
    public GameObject Use;
    public GameObject DescPanel;
    
    public string nome;
    public string descricao1;
    public string descricao2;
    public Item myItem;

    public void fillInformation()
    {
        Nome.text = nome;
        Descricao1.text = descricao1;
        Descricao2.text = descricao2;
        Use.SetActive(true);
        DescPanel.SetActive(true);
        UseButton Usebutton = Use.GetComponent<UseButton>();
        Usebutton.myItem = myItem;
        
    }



}
