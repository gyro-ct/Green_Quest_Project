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
        if(UIFade.instance == null)
        {
            Instantiate(UITransition);
        }
        if(HUD.instance == null)
        {
            Instantiate(Hud);
        }
        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }
    }

}
