using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderFiltro : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController.instance.FiltroAtivado = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        PlayerController.instance.FiltroAtivado = false;
    }
}
