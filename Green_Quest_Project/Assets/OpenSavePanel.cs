using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSavePanel : MonoBehaviour
{
    public GameObject painelSave;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Café");
                painelSave.SetActive(true);
            }
        }
}
