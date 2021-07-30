using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonFornecedorCompras : MonoBehaviour
{
    public TMP_Text Nome;
    public Image Icone;
    public int ID;

    public void OCForn(){
        Debug.Log("Fornecedor");
        CompComprasManager.instance.OnClickFornecedor(ID);
    }
    public void OCEsc(){
        Debug.Log("Escolher");
        CompComprasManager.instance.OnClickEscolher(ID);
    }
}
