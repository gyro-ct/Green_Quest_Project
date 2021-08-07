using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContatosButton : MonoBehaviour
{
    [Header("Painel e Botão")]
    public Sprite imgPersonagem;
    public string nome;
    public string desc;
    public Conv fazerLigacao;
    public int ctID;
    public int cvID;

    public TMP_Text nomeBotao;
    public Image imagemPersonagemPainel;
    public TMP_Text descPainel;
    public TMP_Text nomePainel;

    public GameObject botaoLigar;

    public void popularPainel(){
        nomeBotao.text = nome;
        nomePainel.text = nome;
        imagemPersonagemPainel.sprite = imgPersonagem;
        descPainel.text = desc;
        botaoLigar.SetActive(true);
        LigarButton LBbutton = botaoLigar.GetComponent<LigarButton>();
        LBbutton.callID = cvID;
        LBbutton.contID = ctID;
        LBbutton.conversa = fazerLigacao;
    }

}