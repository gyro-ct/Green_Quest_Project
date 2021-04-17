using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmailManager : MonoBehaviour
{
    public static EmailManager emailManager;
    public Transform EButtonPanel;
    public List <Email> allEmailList = new List<Email>();
    public List <Email> availableEmailList = new List<Email>();
    public List <Email> readEmailList = new List<Email>();
    private List <GameObject> EListButtons = new List<GameObject>();

    public bool EmailTabAction = false;
    public GameObject emailButton;

    void Awake(){
        if(emailManager == null){
            emailManager = this;
        } else if (emailManager != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void FillEmailButtons()
    {   
        if(!EmailTabAction)
        {
            foreach (Email email in readEmailList)
            {
                GameObject EButton = Instantiate(emailButton);
                EmailButton EBbutton = EButton.GetComponent<EmailButton>();
                EBbutton.NomeDesteBotao.text = email.NomeDoRemetente;
                EBbutton.DataDesteBotao.text = email.DataDoEmail;
                EBbutton.TituloDesteBotao.text = email.TituloDoEmail;
                EBbutton.CorpoEmail.text = email.CorpoDoEmail;
                EBbutton.ImagemRemetente = email.ImagemRemetente;
                EBbutton.NomeDoRemetente = email.NomeDoRemetente;
                EBbutton.TituloDoEmail = email.TituloDoEmail;
                EBbutton.CorpoDoEmail = email.CorpoDoEmail;
                EBbutton.DataDoEmail = email.DataDoEmail;
                EBbutton.emailID = email.ID;
                if(email.progress == Email.EmailProgress.READ)
                {
                    EBbutton.lido = true;
                }else
                {
                    EBbutton.lido = false;
                }
                
                EButton.transform.SetParent(EButtonPanel,false);
                EListButtons.Add(EButton);
            }
            foreach (Email email in availableEmailList)
            {
                GameObject EButton = Instantiate(emailButton);
                EmailButton EBbutton = EButton.GetComponent<EmailButton>();
                EBbutton.NomeDesteBotao.text = email.NomeDoRemetente;
                EBbutton.DataDesteBotao.text = email.DataDoEmail;
                EBbutton.TituloDesteBotao.text = email.TituloDoEmail;
                EBbutton.CorpoEmail.text = email.CorpoDoEmail;
                EBbutton.ImagemRemetente = email.ImagemRemetente;
                EBbutton.NomeDoRemetente = email.NomeDoRemetente;
                EBbutton.TituloDoEmail = email.TituloDoEmail;
                EBbutton.CorpoDoEmail = email.CorpoDoEmail;
                EBbutton.DataDoEmail = email.DataDoEmail;
                EBbutton.emailID = email.ID;
                if(email.progress == Email.EmailProgress.READ)
                {
                    EBbutton.lido = true;
                }else
                {
                    EBbutton.lido = false;
                }
                EButton.transform.SetParent(EButtonPanel,false);
                EListButtons.Add(EButton);
            }
            EmailTabAction = true;

        }

    }

    public void hideEmailInformation()
    {
        if(EmailTabAction)
        {
            for (int i = 0; i < EListButtons.Count; i++)
            {
                Destroy(EListButtons[i]);
            }
            EListButtons.Clear();
            EmailTabAction = false;
        }
    }

    public void addEmail(int emailID){
        for (int i=0; i<allEmailList.Count; i++){
            if ((allEmailList[i].ID == emailID) && (allEmailList[i].progress == Email.EmailProgress.NOT_AVAILABLE)){
                allEmailList[i].progress = Email.EmailProgress.AVAILABLE;
                availableEmailList.Add(allEmailList[i]);
            }
        }
    }

    public void readEmail(int emailID){
        for (int i=0; i<availableEmailList.Count; i++){
            if ((availableEmailList[i].ID == emailID) && (availableEmailList[i].progress == Email.EmailProgress.AVAILABLE)){
                availableEmailList[i].progress = Email.EmailProgress.READ;
                readEmailList.Add(availableEmailList[i]);
                for (int j=0; j<allEmailList.Count; j++){
                    if ((allEmailList[j].ID == emailID) && (allEmailList[j].progress == Email.EmailProgress.AVAILABLE)){
                        allEmailList[j].progress = Email.EmailProgress.READ;
                    }
                }
                availableEmailList.RemoveAt(i);
            }
        }
    }

}
