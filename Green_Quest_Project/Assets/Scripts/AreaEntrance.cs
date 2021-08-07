using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    // Done by Area Exit, Do not insert string here
    public string transitionName;
    public string direction;
    public bool semDiretor = true;
    
    void Start()
    {
        Debug.Log("AreaET1: Entrance esta com: " + transitionName);
        if(transitionName == PlayerController.instance.areaTransitionName)
        {
            Debug.Log("AreaET2: Player transform para: " + transform.position);

            PlayerController.instance.transform.position = transform.position;
            
            // If para a fumaça da cidade
            if ((transitionName == "sala_cidade" || transitionName == "cidade_recepcao"
                || transitionName == "producao_garden" || transitionName == "logistica_garden") 
                && (direction == "garden" || direction == "cidade")){
                
                QuestManager.questManager.ativafumaca();
            
            } else {

                QuestManager.questManager.desativarFumaca();

            }

            // If para Diretor na primeira vez da recepção
            if (direction == "corredor"){
                if(EvaController.instance.passouFase5){
                    GameObject.Find("Diretores").transform.Find("Diretor").gameObject.SetActive(false);
                } else {
                    GameObject.Find("Diretores").transform.Find("Diretor").gameObject.SetActive(true);
                }
            }

            // If para caixas da área de comunicação e marketing
            if (direction == "comunicacao"){
                if (NibilaController.instance.achouRelogio){
                    GameObject.Find("itemtest pickup (4)").gameObject.SetActive(false);
                }
                for (int i = 0; i<QuestManager.questManager.questList.Count; i++){
                    if(QuestManager.questManager.questList[i].id == 15 &&
                        QuestManager.questManager.questList[i].progress == Quest.QuestProgress.DONE){
                        GameObject.Find("Caixa1").gameObject.SetActive(false);
                        GameObject.Find("Caixa2").gameObject.SetActive(false);
                        GameObject.Find("Caixa3").gameObject.SetActive(false);
                        GameObject.Find("Caixa4").gameObject.SetActive(false);
                        GameObject.Find("CaixasFalsas").gameObject.SetActive(false);
                    }
                    if(QuestManager.questManager.questList[i].id == 17 &&
                        QuestManager.questManager.questList[i].progress == Quest.QuestProgress.DONE){
                        GameObject.Find("CaixasParaEsvaziar").gameObject.SetActive(false);
                    }
                }
            }

            // If para item da área jurídica
            if (direction == "juridico"){
                if (BrenesController.instance.foundReport){
                    GameObject.Find("itemtest pickup").gameObject.SetActive(false);
                }
            }

            // If para living room
            if (direction == "sala"){
                if (Mother.instance.foundMomLetter){
                    GameObject.Find("itemtest pickup").gameObject.SetActive(false);
                }
            }

            // If para caixas da área logística
            if (direction == "logistica"){
                for (int i = 0; i<QuestManager.questManager.questList.Count; i++){
                    if(QuestManager.questManager.questList[i].id == 25 &&
                        QuestManager.questManager.questList[i].progress == Quest.QuestProgress.DONE){
                        GameObject.Find("Caixas iterativas Amarela").gameObject.SetActive(false);
                        GameObject.Find("Caixas iterativas Roxa").gameObject.SetActive(false);
                    }
                }
            }

            // Ifs para os personagens

            // Mae
            if ((transitionName == "Quarto_sala" || transitionName == "sala_cidade") && (direction == "sala")){
                Debug.Log("IN THE END");
                Mother.instance.gameObject.SetActive(true);
                QuestManager.questManager.deactivatePrg(Mother.instance.gameObject);
            } 
            // Eva
            else if ((transitionName == "corredor_SGA") && (direction == "SGA")){
                EvaController.instance.gameObject.SetActive(true);
                if (EvaController.instance.isOnSGA){
                    EvaController.instance.modeWalk = 28;
                    EvaController.instance.walking = 0;
                    EvaController.instance.toAE(2);
                }
                QuestManager.questManager.deactivatePrg(EvaController.instance.gameObject);
            } else if ((transitionName == "cidade_recepcao") && (direction == "recepcao")){
                for (int i=0; i<QuestManager.questManager.currentQuestList.Count; i++){
                    if (QuestManager.questManager.currentQuestList[i].id == 4){
                        EvaController.instance.gameObject.SetActive(true);
                    }
                }
                QuestManager.questManager.deactivatePrg(EvaController.instance.gameObject);
            } else if ((transitionName == "corredor_recepcao") && (direction == "corredor")){
                for (int i=0; i<QuestManager.questManager.currentQuestList.Count; i++){
                    if (QuestManager.questManager.currentQuestList[i].id == 5 && !EvaController.instance.isOnSGA){
                        EvaController.instance.modeWalk = 2;
                        EvaController.instance.walking = 0;
                        EvaController.instance.toAE(1);
                        EvaController.instance.gameObject.SetActive(true);
                    }
                }
                QuestManager.questManager.deactivatePrg(EvaController.instance.gameObject);
            }
            // Diretoria - Sr. Diretor
            else if (transitionName == "corredor_direcao" && direction == "direcao"){
                DiretorInstance.instance.gameObject.SetActive(true);
                QuestManager.questManager.deactivatePrg(DiretorInstance.instance.gameObject);
            } 
            // Logística - Nebeli
            else if ((transitionName == "corredor_logistica" || transitionName == "logistica_garden") && (direction == "logistica")){
                NebeliController.instance.gameObject.SetActive(true);
                QuestManager.questManager.deactivatePrg(NebeliController.instance.gameObject);
            }
            // Produção - Arah
            else if ((transitionName == "corredor_producao" || transitionName == "producao_garden") && (direction == "producao")){
                ArahController.instance.gameObject.SetActive(true);
                QuestManager.questManager.deactivatePrg(ArahController.instance.gameObject);
            } 
            // Manutenção - Kano
            else if (transitionName == "corredor_manutencao" && direction == "manutencao"){
                KanoController.instance.gameObject.SetActive(true);
                QuestManager.questManager.deactivatePrg(KanoController.instance.gameObject);
            }
            // Compras - Pérsula
            else if (transitionName == "corredor_compras" && direction == "compras"){
                PersulaController.instance.gameObject.SetActive(true);
                QuestManager.questManager.deactivatePrg(PersulaController.instance.gameObject);
            }
            // Jurídico - Brenes
            else if (transitionName == "corredor_juridico" && direction == "juridico"){
                BrenesController.instance.gameObject.SetActive(true);
                QuestManager.questManager.deactivatePrg(BrenesController.instance.gameObject);
            }
            // Comunicação e Marketing - Pessoa [Não é o Sr. Nexus]
            else if (transitionName == "corredor_comunicacao" && direction == "comunicacao"){
                NibilaController.instance.gameObject.SetActive(true);
                QuestManager.questManager.deactivatePrg(NibilaController.instance.gameObject);
            }
            else {
                QuestManager.questManager.deactivatePrg2();
            }
            
        }
        UIFade.instance.fadeFromBlack();
    }
}
