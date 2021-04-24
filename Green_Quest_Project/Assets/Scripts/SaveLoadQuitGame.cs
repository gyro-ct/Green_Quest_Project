using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;

public class SaveLoadQuitGame : MonoBehaviour
{
    public static SaveLoadQuitGame saveLoadQuitGame;
    void Awake(){
        if(saveLoadQuitGame == null){
            saveLoadQuitGame = this;
        } else if (saveLoadQuitGame != this){
            Destroy(gameObject);
        }
    }


    public void Save()
    {
        Save s = new Save();
        //Populando o save. O que precisa ser salvo?
        s.level = 2;
        s.inventory = new List<string>();
        s.inventory.Add("Itemsave");

        SaveGame(s);
        //Save load = LoadGame();
        LoadGame();
        //Debug.Log("LOAD" + load.inventory[0]);
    }

    
    public void SaveGame(Save s)
    {   
        //BinaryFormatter bf = new BinaryFormatter();

        //string path = Application.persistentDataPath; //AppData/LocalLow/Es (Caminho)

        //FileStream file = File.Create(path + "/savegame.save");

        //bf.Serialize(file, s);
        //file.Close();

        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Save", JsonConvert.SerializeObject(s)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

        Debug.Log("Game Salvo!");

    }
    void OnDataSend(UpdateUserDataResult result){
        Debug.Log("Data sent successfuly");
    }

    //public Save LoadGame()
    public void LoadGame()
    {
        //BinaryFormatter bf = new BinaryFormatter(); 

        //string path = Application.persistentDataPath;

        //FileStream file;

        /*if(File.Exists(path + "/savegame.save"))
        {
            file = File.Open(path + "/savegame.save" , FileMode.Open);
            Save l = (Save)bf.Deserialize(file);
            file.Close();

            Debug.Log("Game loaded!");

            return l;
        }*/
        //return null;

        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }
    void OnDataReceived(GetUserDataResult result){
        Debug.Log("Received user data");
        if (result.Data != null && result.Data.ContainsKey("Save")){
            Debug.Log(result.Data["Nome"].Value);
            Save l = JsonConvert.DeserializeObject<Save>(result.Data["Save"].Value);
            Debug.Log("Game loaded!");
            Debug.Log(l);
            // Asynchronous call only resolves OnDataReceived
            Debug.Log("LOAD " + l.inventory[0]);
        } else {
            Debug.Log("Player data not complete");
        }
    }
    
    void OnError(PlayFabError error){
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

}
