using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarPC : MonoBehaviour
{
    public static ativarPC instance;
    public bool ativado=false;
    public bool podeSerAtivado = true;

    private void Awake() {
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
    }
    private void Update() {
        if (ativado && podeSerAtivado && Input.GetKeyDown(KeyCode.Space)){
            CompComprasManager.instance.Entrar();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            ativado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            ativado = false;
        }
    }
}
