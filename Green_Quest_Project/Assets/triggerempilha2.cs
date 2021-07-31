using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerempilha2 : MonoBehaviour
{
    public bool isActive;
    public GameObject colliderEmp1;
    public float waitToLoad = 1f;

    public bool bool1 = false;
    public bool bool2 = false;

    public GameObject TileColliderPlayer;
    public GameObject TileColliderEmpilhadeira;

    void Update()
    {

        // UIFade has to be triggered step by step, that's why two booleans
        if(isActive && NebeliController.instance.isEmpCol2Activated && Input.GetKeyDown(KeyCode.Space)){
            
            Debug.Log("Fade");

            bool1 = true;

            UIFade.instance.fadeToBlack();

        }

        if (bool1){
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                PlayerController.instance.animator.SetBool("EsUmaEmpilhadeira", false);
                PlayerController.instance.transform.position = colliderEmp1.transform.position;
                TileColliderPlayer.SetActive(true);
                TileColliderEmpilhadeira.SetActive(false);
                NebeliController.instance.valor = 3;
                bool2 = true;
                bool1 = false;
            }
        }

        if (bool2){

            UIFade.instance.fadeFromBlack();
            bool2 = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            isActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            isActive = false;
        }
    }
}
