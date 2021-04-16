using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contatos : MonoBehaviour
{
    [Header("Informações do Contato")]
    public Sprite ImagemContato;
    public string NomeDoContato;
    public string DescriçãoDoContato;
    

    [Header("-----------------")]
    public Image ImagemDoContato;
    public TMP_Text NomeNaDescrição;
    public TMP_Text NomeNoBotão;
    public TMP_Text Descrição;

    
   
   
    // Start is called before the first frame update
    public void UpdateContact()
    {
        NomeNoBotão.text = NomeDoContato;
        NomeNaDescrição.text = NomeDoContato;
        Descrição.text = DescriçãoDoContato;
        ImagemDoContato.sprite = ImagemContato;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
