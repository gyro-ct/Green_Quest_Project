using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiaPeixe : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D col){
       //Debug.Log(col.gameObject.tag);
       if(col.gameObject.tag == "Peixe"){
           //Debug.Log("YAY");
           FishGame.fishGame.SetButton(true);
       }
   }
   void OnTriggerStay2D(Collider2D col){
       //Debug.Log(col.gameObject.tag);
       if(col.gameObject.tag == "Peixe"){
           //Debug.Log("YAY");
           FishGame.fishGame.SetButton(true);
       }
   }

   void OnTriggerExit2D(Collider2D col){
       //Debug.Log(col.gameObject.tag+"2");
       if(col.gameObject.tag == "Peixe"){
           //Debug.Log("YAY2");
           FishGame.fishGame.SetButton(false);
       }
   }
}
