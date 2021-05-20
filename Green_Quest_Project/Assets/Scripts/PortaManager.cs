using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaManager : MonoBehaviour
{

    public static PortaManager portaManager;

    public List<Porte> listPortas = new List<Porte>();

    void Awake(){
        if (portaManager == null){
            portaManager = this;
        } else {
            Destroy(portaManager);
        }
        DontDestroyOnLoad(portaManager);

    }

    public void AtivarPorta(int portaID){
        for (int i=0; i<listPortas.Count; i++){
            if (listPortas[i].id == portaID){
                listPortas[i].ativada = true;
            }
        }
    }

    public void DesativarPorta(int portaID){
        for (int i=0; i<listPortas.Count; i++){
            if (listPortas[i].id == portaID){
                listPortas[i].ativada = false;
            }
        }
    }

}
