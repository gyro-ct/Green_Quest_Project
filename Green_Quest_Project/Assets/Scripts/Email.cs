using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

 [System.Serializable]
public class Email
{
    [Header("Informações do Remetente")]
    public Sprite ImagemRemetente;
    public string NomeDoRemetente;
    public string TituloDoEmail;
    public string CorpoDoEmail;
    public int ID;
    public string DataDoEmail;


    public enum EmailProgress
    {
        NOT_AVAILABLE,
        AVAILABLE,
        READ
    }

    public EmailProgress progress;
    
}
