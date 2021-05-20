using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    void Start()
    {
        instance = this;
        //DontDestroyOnLoad(gameObject);
    }
}
