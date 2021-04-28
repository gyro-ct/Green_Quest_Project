using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] Transform topleft;
    [SerializeField] Transform topright;
    [SerializeField] Transform botleft;
    [SerializeField] Transform botright;
    [SerializeField] Transform fish;

    float fishPositionx;
    float fishPositiony;

    float fishDestinationx;
    float fishDestinationy;
    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;
    float fishSpeedx;
    float fishSpeedy;
    [SerializeField] float smoothMotion = 1.15f;

    void Start(){
        fishPositionx = Random.value;
        fishPositiony = Random.value;
    }

    void Update(){
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f){
            fishTimer = Random.value * timerMultiplicator;
            fishDestinationx = Random.value;
            fishDestinationy = Random.value;
            //Debug.Log("FishPDest " + fishDestinationx + " " + fishDestinationy);
        }

        fishPositionx = Mathf.SmoothDamp(fishPositionx, fishDestinationx, ref fishSpeedx, smoothMotion);
        fishPositiony = Mathf.SmoothDamp(fishPositiony, fishDestinationy, ref fishSpeedy, smoothMotion);
        //Debug.Log("Fishx " +  fishPositionx);
        //Debug.Log("Fishy " +  fishPositiony);
        fish.position = new Vector3(Mathf.Lerp(botleft.position.x, botright.position.x, fishPositionx),
                                    Mathf.Lerp(topleft.position.y, botleft.position.y, fishPositiony),
                                    1f);
    }
}
