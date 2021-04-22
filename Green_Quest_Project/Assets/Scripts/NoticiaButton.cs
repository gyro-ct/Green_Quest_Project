using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NoticiaButton : MonoBehaviour
{
    public string InicialDaImagem;
    public string FonteDaNoticia;
    public string TituloDaNoticia;
    public string TextoDaNoticia;
    public string DataDaNoticia;
    public int noticiaID;
    public bool lido;


    [Header("Variáveis do Painel da Notícia")]
    public TMP_Text FonteNaNoticia;
    public TMP_Text TituloNaNoticia;
    public TMP_Text TextoNaNoticia;
    public TMP_Text DataNaNoticia;
    public GameObject ImagemLido;
    public TMP_Text InicialDaImagemNaNoticia;

    [Header("Variáveis do Botão")]
    public TMP_Text TituloDoBotao;
    public TMP_Text FonteDoBotao;
    public TMP_Text DescricaoDoBotao;


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
    public void UpdateNoticiaInfo()
    {
        NoticiaManager.noticiaManager.readNoticia(noticiaID);
        FonteNaNoticia.text = FonteDaNoticia;
        DataNaNoticia.text = DataDaNoticia;
        TituloNaNoticia.text = TituloDaNoticia;
        TextoNaNoticia.text = TextoDaNoticia;
        InicialDaImagemNaNoticia.text = InicialDaImagem;

    }
}