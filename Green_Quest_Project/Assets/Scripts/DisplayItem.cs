using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayItem : MonoBehaviour
{
    public InventarioControlador item;
    public TMP_Text quantidadeTexto;
    public TMP_Text NomeDoItem;
    public TMP_Text descrição1;
    public TMP_Text descrição2;
    public Image iconeDoItem;

    void Start()
    {
        quantidadeTexto.text = "" + item.quantidade;
        NomeDoItem.text = "" + item.NomeDoItem;
        descrição1.text = "" + item.descrição1;
        descrição2.text = "" + item.descrição2;
        iconeDoItem.sprite = item.icone;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
