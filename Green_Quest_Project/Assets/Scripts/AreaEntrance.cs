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

            if (QuestManager.questManager.ConversationMainTrigger == 4){
                EvaController.instance.toAE(1);
                EvaController.instance.gameObject.SetActive(true);
                PortaManager.portaManager.DesativarPorta(4);
            } else if (transitionName == "corredor_recepcao"){
                Debug.Log("YAYAYYYA");
                EvaController.instance.gameObject.SetActive(false);
            }
            PlayerController.instance.transform.position = transform.position;
        }
        UIFade.instance.fadeFromBlack();
    }
}
