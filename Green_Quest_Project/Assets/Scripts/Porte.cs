using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

[System.Serializable]
public class Porte
{
    public int id;
    public bool ativada;
    public bool ativarConversaPassiva = false;
    public NPCConversation conversaPassiva;

}
