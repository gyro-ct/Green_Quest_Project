using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Item", menuName = "Inventario/Criar", order = 1)]


public class InventarioControlador : ScriptableObject
{
    public int IDDoItem;
    public string NomeDoItem;
    public Sprite icone;
    public int quantidade;
    public string descrição1;
    [UnityEngine.TextArea]
    public string descrição2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
