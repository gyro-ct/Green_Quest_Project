using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarkerManager : MonoBehaviour
{

    public static QuestMarkerManager questMarkerManager;
    public List <MarkerQuestTrigger> questMarkerList = new List<MarkerQuestTrigger>();

    // Start is called before the first frame update
    void Awake()
    {
        if(questMarkerManager == null){
            questMarkerManager = this;
        } else if (questMarkerManager != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    

}
