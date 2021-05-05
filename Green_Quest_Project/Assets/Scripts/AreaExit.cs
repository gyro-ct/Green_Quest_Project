using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    // Place all references here
    public string areaToLoad;
    public string areaTransitionName;
    public AreaEntrance theEntrance;
    public float waitToLoad = 1f;
    private bool shoudLoadAfterFade;
    
    void Start()
    {
        theEntrance.transitionName = areaTransitionName;
    }

    void Update()
    {
        if(shoudLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shoudLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //SceneManager.LoadScene(areaToLoad);
            shoudLoadAfterFade = true;
            UIFade.instance.fadeToBlack();
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
