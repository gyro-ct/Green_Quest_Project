using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

 [System.Serializable]
public class Noticia
{
    [Header("Informações do Remetente")]
    public string InicialDaImagem;
    public string FonteDaNoticia;
    public string TituloDaNoticia;
    [UnityEngine.TextArea]
    public string TextoDaNoticia;
    public int ID;
    public string DataDaNoticia;


    public enum NoticiaProgress
    {
        NOT_AVAILABLE,
        AVAILABLE,
        READ
    }

    public NoticiaProgress progress;
}