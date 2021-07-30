using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    // Done by Area Exit, Do not insert string here
    public string transitionName;
    
    void Start()
    {
        Debug.Log("AreaET1: Entrance esta com: " + transitionName);
        if(transitionName == PlayerController.instance.areaTransitionName)
        {
            Debug.Log("AreaET2: Player transform para: " + transform.position);

            PlayerController.instance.transform.position = transform.position;
            
            if (transitionName == "sala_cidade" || transitionName == "cidade_recepcao"
                || transitionName == "producao_garden" || transitionName == "logistica_garden"){
                Debug.Log(QuestManager.questManager.isActive());
                if (!QuestManager.questManager.isActive()){
                    Debug.Log("Fumaça ativada");
                    QuestManager.questManager.ativafumaca();
                } else {
                    QuestManager.questManager.desativarFumaca();
                }
            }

            Debug.Log("HOPE");
            if (QuestManager.questManager.ConversationMainTrigger == 4){
                
                Debug.Log("YAYAYYYA2222");
                EvaController.instance.toAE(1);
                EvaController.instance.gameObject.SetActive(true);
                PortaManager.portaManager.DesativarPorta(4);

            } else if (transitionName == "corredor_SGA"){
                // EvaController.instance.toAE(1);
                EvaController.instance.gameObject.SetActive(true);
            } else if (transitionName == "corredor_producao" || transitionName == "producao_garden"){

                ArahController.instance.gameObject.SetActive(true);
                Debug.Log("LOG ativar");
                if (!ArahController.instance.activeTrigger){
                    Debug.Log("LOG desativar1");
                    ArahController.instance.activeTrigger = true;
                    ArahController.instance.gameObject.SetActive(false);
                } else {
                    Debug.Log("LOG desativar2");
                    ArahController.instance.activeTrigger = false;
                }
                QuestManager.questManager.deactivatePrg(ArahController.instance.gameObject);

            } else if (transitionName == "corredor_manutencao"){

                KanoController.instance.gameObject.SetActive(true);
                Debug.Log("LOG ativar");
                if (!KanoController.instance.activeTrigger){
                    Debug.Log("LOG desativar1");
                    KanoController.instance.activeTrigger = true;
                    KanoController.instance.gameObject.SetActive(false);
                } else {
                    Debug.Log("LOG desativar2");
                    KanoController.instance.activeTrigger = false;
                }
                QuestManager.questManager.deactivatePrg(KanoController.instance.gameObject);

            } else if (transitionName == "corredor_direcao"){

                DiretorInstance.instance.gameObject.SetActive(true);
                Debug.Log("LOG ativar");
                if (!DiretorInstance.instance.activeTrigger){
                    Debug.Log("LOG desativar1");
                    DiretorInstance.instance.activeTrigger = true;
                    DiretorInstance.instance.gameObject.SetActive(false);
                } else {
                    Debug.Log("LOG desativar2");
                    DiretorInstance.instance.activeTrigger = false;
                }
                QuestManager.questManager.deactivatePrg(DiretorInstance.instance.gameObject);

            }  else if (transitionName == "corredor_compras"){

                PersulaController.instance.gameObject.SetActive(true);
                Debug.Log("LOG ativar");
                if (!PersulaController.instance.activeTrigger){
                    Debug.Log("LOG desativar1");
                    PersulaController.instance.activeTrigger = true;
                    PersulaController.instance.gameObject.SetActive(false);
                } else {
                    Debug.Log("LOG desativar2");
                    PersulaController.instance.activeTrigger = false;
                }
                QuestManager.questManager.deactivatePrg(PersulaController.instance.gameObject);
                

            } else {
                Debug.Log("YAYAYYYA");
                QuestManager.questManager.deactivatePrg2();
            }
            
        }
        UIFade.instance.fadeFromBlack();
    }
}
