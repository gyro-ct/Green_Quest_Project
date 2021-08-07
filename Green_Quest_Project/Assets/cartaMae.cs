using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaMae : MonoBehaviour
{
    private void OnDestroy() {
        if(!Mother.instance.foundMomLetter){
            Mother.instance.foundMomLetter = true;
        }
    }
}
