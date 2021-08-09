using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NoticiaManager : MonoBehaviour
{
    public static NoticiaManager noticiaManager;
    public Transform NButtonPanel;
    public List <Noticia> allNoticiaList = new List<Noticia>();
    public List <Noticia> availableNoticiaList = new List<Noticia>();
    public List <Noticia> readNoticiaList = new List<Noticia>();
    private List <GameObject> NListButtons = new List<GameObject>();

    public bool NoticiaTabAction = false;
    public GameObject noticiaButton;
    public GameObject painelDaNoticia;

    void Awake(){
        if(noticiaManager == null){
            noticiaManager = this;
        } else if (noticiaManager != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        for (int i = 0; i < allNoticiaList.Count; i++){
            if (allNoticiaList[i].progress == Noticia.NoticiaProgress.AVAILABLE){
                availableNoticiaList.Add(allNoticiaList[i]);
            }
        } 
    }

    public void FillNoticiaButtons()
    {   
        if(!NoticiaTabAction)
        {
            foreach (Noticia noticia in readNoticiaList)
            {
                GameObject NButton = Instantiate(noticiaButton);
                NoticiaButton NBbutton = NButton.GetComponent<NoticiaButton>();
                NBbutton.TituloDoBotao.text = noticia.TituloDaNoticia;
                NBbutton.FonteDoBotao.text = noticia.FonteDaNoticia;
                NBbutton.DescricaoDoBotao.text = noticia.TextoDaNoticia;
                NBbutton.InicialDaImagem = noticia.InicialDaImagem;
                NBbutton.FonteDaNoticia = noticia.FonteDaNoticia;
                NBbutton.TituloDaNoticia = noticia.TituloDaNoticia;
                NBbutton.TextoDaNoticia = noticia.TextoDaNoticia;
                NBbutton.DataDaNoticia = noticia.DataDaNoticia;
                NBbutton.noticiaID = noticia.ID;
                if(noticia.progress == Noticia.NoticiaProgress.READ)
                {
                    NBbutton.lido = true;
                }else
                {
                    NBbutton.lido = false;
                }
                
                NButton.transform.SetParent(NButtonPanel,false);
                NListButtons.Add(NButton);
            }
            foreach (Noticia noticia in availableNoticiaList)
            {
                GameObject NButton = Instantiate(noticiaButton);
                NoticiaButton NBbutton = NButton.GetComponent<NoticiaButton>();
                NBbutton.TituloDoBotao.text = noticia.TituloDaNoticia;
                NBbutton.FonteDoBotao.text = noticia.FonteDaNoticia;
                NBbutton.DescricaoDoBotao.text = noticia.TextoDaNoticia;
                NBbutton.InicialDaImagem = noticia.InicialDaImagem;
                NBbutton.FonteDaNoticia = noticia.FonteDaNoticia;
                NBbutton.TituloDaNoticia = noticia.TituloDaNoticia;
                NBbutton.TextoDaNoticia = noticia.TextoDaNoticia;
                NBbutton.DataDaNoticia = noticia.DataDaNoticia;
                NBbutton.noticiaID = noticia.ID;
                if(noticia.progress == Noticia.NoticiaProgress.READ)
                {
                    NBbutton.lido = true;
                }else
                {
                    NBbutton.lido = false;
                }
                
                NButton.transform.SetParent(NButtonPanel,false);
                NListButtons.Add(NButton);
            }
            NoticiaTabAction = true;

        }

    }

    public void hideNoticiaInformation()
    {
        if(NoticiaTabAction)
        {
            for (int i = 0; i < NListButtons.Count; i++)
            {
                Destroy(NListButtons[i]);
            }
            NListButtons.Clear();
            painelDaNoticia.SetActive(false);
            NoticiaTabAction = false;
        }
    }

    public void addNoticia(int noticiaID){
        for (int i=0; i<allNoticiaList.Count; i++){
            if ((allNoticiaList[i].ID == noticiaID) && (allNoticiaList[i].progress == Noticia.NoticiaProgress.NOT_AVAILABLE)){
                allNoticiaList[i].progress = Noticia.NoticiaProgress.AVAILABLE;
                availableNoticiaList.Add(allNoticiaList[i]);
            }
        }
    }

    public void readNoticia(int noticiaID){
        for (int i=0; i<availableNoticiaList.Count; i++){
            if ((availableNoticiaList[i].ID == noticiaID) && (availableNoticiaList[i].progress == Noticia.NoticiaProgress.AVAILABLE)){
                availableNoticiaList[i].progress = Noticia.NoticiaProgress.READ;
                readNoticiaList.Add(availableNoticiaList[i]);
                for (int j=0; j<allNoticiaList.Count; j++){
                    if ((allNoticiaList[j].ID == noticiaID) && (allNoticiaList[j].progress == Noticia.NoticiaProgress.AVAILABLE)){
                        allNoticiaList[j].progress = Noticia.NoticiaProgress.READ;
                    }
                }
                availableNoticiaList.RemoveAt(i);
            }
        }
    }
}
