using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject Hud;
    public GameObject UITransition;
    public GameObject player;

    void Awake()
    {
        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }
        if(UIFade.instance == null)
        {
            Instantiate(UITransition);
        }
        if(HUD.instance == null)
        {
            Instantiate(Hud);
        }
        
    }

}
