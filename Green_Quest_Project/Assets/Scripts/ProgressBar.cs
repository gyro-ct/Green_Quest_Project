using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private Slider slider;
    public float FillSpeed = 50f;
    public float targetProgress = 0f;
    public string type; 

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        
    }

    void Start()
    {
        // IncrementProgress(0.75f);
        slider.value = 0f;
        if (type == "XP"){
            IncrementProgress(PlayerController.instance.Experience);
        } else if (type == "Stamina"){
            Debug.Log(PlayerController.instance.Stamina);
            IncrementProgress(PlayerController.instance.Stamina);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Up "+targetProgress+" "+slider.value);
        // Time.deltaTime
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * 0.1f;
        }
        else if (slider.value > targetProgress)
        {
            slider.value -= FillSpeed * 0.1f;
        }
            
    }

    public void IncrementProgress (float newprogress)
    {
        Debug.Log("SLIDEr" + slider);
        Debug.Log(slider.value);
        targetProgress = slider.value + newprogress;
    }
}
