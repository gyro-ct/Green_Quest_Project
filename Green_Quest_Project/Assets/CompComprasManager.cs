using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DialogueEditor;

public class CompComprasManager : MonoBehaviour
{
    public static CompComprasManager instance;

    public List<Fornecedores> ListaFornecedores = new List<Fornecedores>();
    public List<GameObject> qForn = new List<GameObject>();
    // public List<int> FornecedoresEscolhidos = new List<int>();
    public int EResult;
    public int AResult;

    public bool EntrouUmaVez = false;

    void Awake(){
        if (instance == null){
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public GameObject PainelFUnico;
    public GameObject PainelPrincipal;
    public Transform PainelPrincipalT;
    public GameObject PainelF;
    public GameObject SairButton;
    public GameObject FButton;

    // Fill fornecedores with buttons

    public void FillFornecedores(){
        foreach (Fornecedores f in ListaFornecedores){
            GameObject FBt = Instantiate(FButton);
            ButtonFornecedorCompras BFC = FBt.GetComponent<ButtonFornecedorCompras>();
            BFC.ID = f.FornID;
            BFC.Nome.text = f.nome;
            BFC.transform.SetParent(PainelPrincipalT, false);
            qForn.Add(FBt);
        }
    }

    // OnClick botão escolher

    public TMP_Text Escolher;
    public NPCConversation convG3;
    public NPCConversation convF7;

    public void OnClickEscolher(int id){
        for (int forn = 0; forn < ListaFornecedores.Count; forn++){
            if (ListaFornecedores[forn].FornID == id){         
                if (ListaFornecedores[forn].tipoFiltro == "G3"){
                    if (escolhaG3()){
                        if (escolhaG3_2() != ListaFornecedores[forn]){
                            ConversationManager.Instance.StartConversation(convG3);
                            return;
                        }
                    }
                } else {
                    if (escolhaF7()){
                        if (escolhaF7_2() != ListaFornecedores[forn]){
                            ConversationManager.Instance.StartConversation(convF7);
                            return;
                        }
                    }
                }

                if (ListaFornecedores[forn].estaEscolhido){
                    Escolher.text = "Remover";
                } else {
                    Escolher.text = "Escolher";
                }

                ListaFornecedores[forn].estaEscolhido = !ListaFornecedores[forn].estaEscolhido;
                PainelFUnico.SetActive(false);
                PainelF.SetActive(true);
                SairButton.SetActive(true);
                
            }
        }
    }

    // OnClick botão fornecedor
    

    public void OnClickFornecedor(int id){
        for (int forn = 0; forn < ListaFornecedores.Count; forn++){
            if (ListaFornecedores[forn].FornID == id){         

                PainelF.SetActive(false);
                PainelFUnico.SetActive(true);
                SairButton.SetActive(false);
                InfoPainel Info = PainelFUnico.GetComponent<InfoPainel>();
                Info.foto.sprite = ListaFornecedores[forn].imagem;
                if (ListaFornecedores[forn].estaEscolhido){
                    Info.escolha.text = "Remover";
                } else {
                    Info.escolha.text = "Escolher";
                }
                Info.BotaoEscolher.GetComponent<ButtonFornecedorCompras>().ID = id;
                Info.E.GetComponent<ProgressBar>().targetProgress = ListaFornecedores[forn].ValorEcon;
                Info.A.GetComponent<ProgressBar>().targetProgress = ListaFornecedores[forn].ValorAmb;
                Info.desc.text = "Filtro: " + ListaFornecedores[forn].tipoFiltro + "\n" + ListaFornecedores[forn].Descricao;
            }
        }
    }

    // Entrar, Voltar e Sair

    public GameObject HUDCanvas;
    public void Entrar(){
        EntrouUmaVez = true;
        PainelPrincipal.SetActive(true);
        PainelF.SetActive(true);
        SairButton.SetActive(true);
        HUDCanvas.SetActive(false);
        FillFornecedores();
    }

    public void Voltar(){
        PainelF.SetActive(true);
        SairButton.SetActive(true);
        PainelFUnico.SetActive(false);
    }

    public NPCConversation convEscolher2;

    public void Sair(){
        if (escolhaF7() && escolhaG3()){
            somar();
            PainelFUnico.SetActive(false);
            PainelPrincipal.SetActive(false);
            SairButton.SetActive(false);
            PainelF.SetActive(false);
            HUDCanvas.SetActive(true);
            foreach (GameObject b in qForn){
                Destroy(b);
            }
            qForn.Clear();
            resetList();
        } else {
            ConversationManager.Instance.StartConversation(convEscolher2);
        }
    }

    public void resetList(){
        for (int i = 0; i < ListaFornecedores.Count; i++){
            if (ListaFornecedores[i].estaEscolhido){
                ListaFornecedores[i].estaEscolhido = false;
            }
        }
    }

    // Somar os resultados e retornar os resultados

    public bool passouComp;

    public void somar(){
        int somaE = 0;
        int somaA = 0;
        for (int i = 0; i < ListaFornecedores.Count; i++){
            if (ListaFornecedores[i].estaEscolhido){
                somaE += ListaFornecedores[i].ValorEcon;
                somaA += ListaFornecedores[i].ValorAmb;
            }
        }
        if (somaA > 100 && somaE < 75){
            passouComp = true;
        } else {
            passouComp = false;
        }
    }

    // Contar quantos faltam
    public int numeroEscolhidos(){
        int a = 0;
        for (int i = 0; i < ListaFornecedores.Count; i++){
            if (ListaFornecedores[i].estaEscolhido){
                a++;
            }
        }
        return a;
    }

    // Verificar tipos de filtro escolhidos
    public bool escolhaG3(){
        for (int i = 0; i < ListaFornecedores.Count; i++){
            if (ListaFornecedores[i].estaEscolhido && ListaFornecedores[i].tipoFiltro == "G3"){
                return true;
            }
        }
        return false;
    }
    public bool escolhaF7(){
        for (int i = 0; i < ListaFornecedores.Count; i++){
            if (ListaFornecedores[i].estaEscolhido && ListaFornecedores[i].tipoFiltro == "F7"){
                return true;
            }
        }
        return false;
    }

    public Fornecedores escolhaG3_2(){
        for (int i = 0; i < ListaFornecedores.Count; i++){
            if (ListaFornecedores[i].estaEscolhido && ListaFornecedores[i].tipoFiltro == "G3"){
                return ListaFornecedores[i];
            }
        }
        Debug.Log("PERIGO");
        return ListaFornecedores[0];
    }
    public Fornecedores escolhaF7_2(){
        for (int i = 0; i < ListaFornecedores.Count; i++){
            if (ListaFornecedores[i].estaEscolhido && ListaFornecedores[i].tipoFiltro == "F7"){
                return ListaFornecedores[i];
            }
        }
        Debug.Log("PERIGO");
        return ListaFornecedores[0];
    }

}
