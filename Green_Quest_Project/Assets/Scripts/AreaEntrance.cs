using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    // Done by Area Exit, Do not insert string here
    public string transitionName;
    
    void Start()
    {
        if(transitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }
        UIFade.instance.fadeFromBlack();
    }
}
