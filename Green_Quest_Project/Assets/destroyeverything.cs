using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyeverything : MonoBehaviour
{
    // Start is called before the first frame update

    public static destroyeverything instance;
    void Start()
    {
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
    }

    public void DestroyEveryInstance(){
        for (int i = 0; i < QuestManager.questManager.PrgInstances.Count; i++){
            Destroy(QuestManager.questManager.PrgInstances[i]);
        }
        Destroy(GameObject.Find("Player(Clone)"));
        Destroy(GameObject.Find("HUD_Menus(Clone)"));
        Destroy(GameObject.Find("UIFade(Clone)"));
        SceneManager.LoadScene("LoginScene");

    }
}
