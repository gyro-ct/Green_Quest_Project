using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarManager : MonoBehaviour
{
    public GameObject StaminaBarMochila;
    public GameObject StaminaBarHUD;
    public GameObject XPBarMochila;
    public List <GameObject> ListBars = new List<GameObject>();
    public static ProgressBarManager ProgressBarInstance;

    private void Awake()
    {
        if(ProgressBarInstance == null){
            ProgressBarInstance = this;
        } else if (ProgressBarInstance != this){
            Destroy(gameObject);
        }
    }

    public List<GameObject> getObjects(){
        ListBars.Clear();
        ListBars.Add(StaminaBarMochila);
        ListBars.Add(StaminaBarHUD);
        //ListBars.Add(XPBarMochila);
        Debug.Log("LOLZ"+ListBars.Count);
        return ListBars;
    }

    public GameObject getObjectsXP(){
        return XPBarMochila;
    }

}
