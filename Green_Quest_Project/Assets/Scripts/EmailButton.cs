using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailButton : MonoBehaviour
{
    public Sprite ImagemRemetente;
    public string NomeDoRemetente;
    public string TituloDoEmail;
    public string CorpoDoEmail;
    public string DataDoEmail;
    public int emailID;
    public bool lido;
    

    [Header("-----------------")]
    public Image ImagemDoRemetente;
    public TMP_Text NomeNoEmail;
    public TMP_Text TituloEmail;
    public TMP_Text CorpoEmail;
    public TMP_Text DataEmail;
    public GameObject ImagemLido;


    public TMP_Text NomeDesteBotao;
    public TMP_Text DataDesteBotao;
    public TMP_Text TituloDesteBotao;


    void Start()
    {
        if(lido)
        {
            ImagemLido.SetActive(false);
        }else
        {
            ImagemLido.SetActive(true);
        }
    }


    // Quando o botão é clicado
    public void UpdateEmailInfo()
    {
        EmailManager.emailManager.readEmail(emailID);
        NomeNoEmail.text = NomeDoRemetente;
        DataEmail.text = DataDoEmail;
        TituloEmail.text = TituloDoEmail;
        CorpoEmail.text = CorpoDoEmail;
        ImagemDoRemetente.sprite = ImagemRemetente;
    }
}
