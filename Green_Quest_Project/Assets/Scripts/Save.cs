using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class Save
{   
    //Variáveis a serem salvas
    public int level;
    public List<string> inventory;
    public List<int> currentQuests;
    public List<int> availableQuests;
    public string scene;

}

