using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarBrenes : MonoBehaviour
{

    private void OnDestroy() {
        BrenesController.instance.valor = 5;
    }
                
}
