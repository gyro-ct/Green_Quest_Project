using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using DialogueEditor;
using UnityEngine.UI;
using TMPro;

public class ConvManager : MonoBehaviour
{
    public static ConvManager convManager;
    public GameObject contButton;
    public Transform CButtonPanel;    
    private List <GameObject> CListButtons = new List<GameObject>();

    public List <Conv> convList = new List<Conv>(); // Lista mestre de Convs
    public List <Contato> contList = new List<Contato>();
    private bool ContactTabAction = false;

    // Inicialização e verificação se não há duplicatas
    void Awake(){
        if(convManager == null){
            convManager = this;
        } else if (convManager != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Retornar uma conversa a partir de uma quest ID
    public Conv GetQuestCall(int callID){
        for (int i = 0; i < convList.Count; i++){
            if (convList[i].ID == callID){
                return convList[i];
            }
        } return null;
    }

    public Image imagemPersonagemPainel;
    public TMP_Text descPainel;
    public TMP_Text nomePainel;
    public GameObject botaoAtender;

    public GameObject receiveCallCanvas;

    public void ActivateReceiveCallCanvas(int callID, int contactID){
        receiveCallCanvas.SetActive(true);
        for (int i=0; i<contList.Count; i++){
            if (contList[i].ID == contactID){
                nomePainel.text = contList[i].nome;
                imagemPersonagemPainel.sprite = contList[i].imgPersonagem;
                descPainel.text = contList[i].desc;
                botaoAtender.SetActive(true);
                LigarButton LBbutton = botaoAtender.GetComponent<LigarButton>();

                for (int j=0; j<convList.Count; j++){
                    if(convList[j].ID == callID){
                        LBbutton.conversa = convList[j];
                    }
                }
            }
        }
    }

    // Popular os botões (Set/Hide)
    public void FillContactButtons()
    {
        if(!ContactTabAction)
        {
            foreach (Contato contato in contList)
            {
                GameObject CButton = Instantiate(contButton);
                ContatosButton CBbutton = CButton.GetComponent<ContatosButton>();
                CBbutton.imgPersonagem = contato.imgPersonagem;
                CBbutton.nome = contato.nome;
                CBbutton.desc = contato.nome;
                CBbutton.fazerLigacao = contato.LigacaoPadrao;
                CBbutton.nomeBotao.text = contato.nome;
                CBbutton.descPainel.text = contato.desc;
                CBbutton.nomePainel.text = contato.nome;
                CBbutton.imagemPersonagemPainel.sprite = contato.imgPersonagem;
                
                CButton.transform.SetParent(CButtonPanel,false);
                CListButtons.Add(CButton);
            }
            ContactTabAction = true;
        }
    }
    public void HideContactsInformation()
    {
        if(ContactTabAction)
        {
            for (int i = 0; i < CListButtons.Count; i++)
            {
                Destroy(CListButtons[i]);
            }
            CListButtons.Clear();
            ContactTabAction = false;
        }
    }

}
