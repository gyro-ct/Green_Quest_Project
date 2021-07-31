using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaMovement : MonoBehaviour
{
    public Vector3 target = Vector3.zero;
    public bool canMove = false;

    // Update is called once per frame
    void Update()
    {
        if (canMove){
            moveIt();
        }
    }

    public void moveIt(){
        Vector3 direction = (target - transform.position).normalized;
        Rigidbody2D RGB = GetComponent<Rigidbody2D>();
        RGB.velocity = direction * 3;

        Vector3 seila = target - transform.position;
        float s = Mathf.Abs(seila.x) + Mathf.Abs(seila.y) + Mathf.Abs(seila.z);

        if (target == transform.position){
            canMove = false;
            RGB.velocity = Vector3.zero;
        } else if (s < 0.09) {
            canMove = false;
            RGB.velocity = Vector3.zero;
        }

        //transform.position = Vector3.MoveTowards(transform.position,
        //                                        target, smoothTime*Time.deltaTime);
    }

    public bool act = false;

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player"){
            PlayerController.instance.canMove = false;
            float hh = PlayerController.instance.lastHorizontal;
            float vv = PlayerController.instance.lastVertical;

            Debug.Log("H: " + hh + "V: " + vv);
            if (hh != 0){
                if (hh == 1){
                    target = new Vector3(Mathf.Floor((transform.position.x + 1.5f)*100.0f)/100.0f, 
                                         Mathf.Floor(transform.position.y*100.0f)/100.0f, 
                                         Mathf.Floor(transform.position.z*100.0f)/100.0f);
                    canMove = true;
                } else if (hh == -1){
                    target = new Vector3(Mathf.Floor((transform.position.x - 1.5f)*100.0f)/100.0f, 
                                         Mathf.Floor(transform.position.y*100.0f)/100.0f, 
                                         Mathf.Floor(transform.position.z*100.0f)/100.0f);
                    canMove = true;
                }
            } else if (vv != 0){
                if (vv == 1){
                    target = new Vector3(Mathf.Floor(transform.position.x*100.0f)/100.0f, 
                                         Mathf.Floor((transform.position.y + 1.5f)*100.0f)/100.0f, 
                                         Mathf.Floor(transform.position.z*100.0f)/100.0f);
                    canMove = true;
                } else if (vv == -1){
                    target = new Vector3(Mathf.Floor(transform.position.x*100.0f)/100.0f, 
                                         Mathf.Floor((transform.position.y - 1.5f)*100.0f)/100.0f, 
                                         Mathf.Floor(transform.position.z*100.0f)/100.0f);
                    canMove = true;
                }
            }
            if(canMove){
                PlayerController.instance.startCo2(0.5f);
            } else {
                PlayerController.instance.canMove = true;
                PlayerController.instance.canInteract = true;
            }
        }

        if (other.tag == "T1"){
            if (!act){
                act = true;
                NibilaController.instance.addQuestItem();
                Destroy(gameObject);
            }
        }
        
    }
}
