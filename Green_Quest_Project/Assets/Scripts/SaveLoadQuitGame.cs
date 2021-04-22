using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadQuitGame : MonoBehaviour
{
    
    public void Save()
    {
        Save s = new Save();
        //Populando o save. O que precisa ser salvo?
        s.level = 2;
        s.inventory = new List<string>();
        s.inventory.Add("Itemsave");

        SaveGame(s);

        Save load = LoadGame();
        Debug.Log(load.inventory[0]);
    }

    
    public void SaveGame(Save s)
    {   
        BinaryFormatter bf = new BinaryFormatter(); 

        string path = Application.persistentDataPath; //AppData/LocalLow/Es (Caminho)

        FileStream file = File.Create(path + "/savegame.save");

        bf.Serialize(file, s);
        file.Close();

        Debug.Log("Game Salvo!");

    }

    public Save LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); 

        string path = Application.persistentDataPath;

        FileStream file;

        if(File.Exists(path + "/savegame.save"))
        {
            file = File.Open(path + "/savegame.save" , FileMode.Open);
            Save l = (Save)bf.Deserialize(file);
            file.Close();

            Debug.Log("Game loaded!");

            return l;
        }
        return null;
    }   
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

}
