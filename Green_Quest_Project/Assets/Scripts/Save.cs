using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{   
    // Cena em que foi salvo o jogo
    public string SavingScene;

    // Posição do player [px, py, pz]
    public List<float> position = new List<float>();

    // Active instances
    public List<string> activeInstances = new List<string>();

    // Valores e Booleanas do PlayerController e Controller dos personagens
    public Dictionary<string, int> PlayerAndCharacterValues = new Dictionary<string, int>();
    public Dictionary<string, bool> PlayerAndCharacterBools = new Dictionary<string, bool>();

    // lista de ids do QuestUIManager
    public List<int> availableQuests = new List<int>();
    public List<int> activeQuests = new List<int>();

    // lista de ids de itens do ItemManager
    public List<int> inventory = new List<int>();

    // lista de contatos ativos do ConvManager
    public List<int> conversas = new List<int>();

    // lista de booleanas, inteiros e listas padrão do QuestManager
    public List<bool> questManagerBools = new List<bool>();
    public int convMainTrigger;
    public List<int> currentQuestList = new List<int>();
    public List<int> currntQuestProvCanvas = new List<int>();

    // lista de portas ativas
    public List<int> activeDoors = new List<int>();

    // lista de notícias ativas
    public List<int> availableNoticias = new List<int>();
    public List<int> readNoticias = new List<int>();

    // lista de emails ativas
    public List<int> availableEmails = new List<int>();
    public List<int> readEmails = new List<int>();

}

