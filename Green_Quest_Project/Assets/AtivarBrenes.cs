using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarBrenes : MonoBehaviour
{

    private void OnDestroy() {
        QuestManager.questManager.AddQuestItem("Xerox do relatório", 1);
    }
                
}
