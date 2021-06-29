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
        }
        UIFade.instance.fadeFromBlack();
    }
}
