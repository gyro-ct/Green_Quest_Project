using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSavePanel : MonoBehaviour
{
    public GameObject painelSave;
    public bool ativada = false;

    private void Update() {
        if (ativada && Input.GetKeyDown(KeyCode.Space)){
            painelSave.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Café");
            ativada = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Café");
            ativada = false;
        }
    }
}
