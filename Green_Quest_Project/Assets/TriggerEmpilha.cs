using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEmpilha : MonoBehaviour
{
    public bool isActive;
    public GameObject colliderEmp2;
    public float waitToLoad = 1f;

    public bool bool1 = false;
    public bool bool2 = false;

    public GameObject TileColliderPlayer;
    public GameObject TileColliderEmpilhadeira;

    void Update()
    {

        // UIFade has to be triggered step by step, that's why two booleans
        if(isActive && NebeliController.instance.isEmpCol1Activated && Input.GetKeyDown(KeyCode.Space)){
            
            Debug.Log("Fade");

            bool1 = true;

            UIFade.instance.fadeToBlack();

        }

        if (bool1){
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                PlayerController.instance.animator.SetBool("EsUmaEmpilhadeira", true);
                PlayerController.instance.transform.position = colliderEmp2.transform.position;
                TileColliderPlayer.SetActive(false);
                TileColliderEmpilhadeira.SetActive(true);
                NebeliController.instance.liberarCaixas();
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
