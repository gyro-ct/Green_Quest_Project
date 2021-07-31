using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trrriger : MonoBehaviour
{
    public bool isOnCollider;
    private void Start() {
        isOnCollider = false;
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.tag == "T1"){
            Debug.Log("TriggerEnter");
            isOnCollider = true;
        }
    }
}
