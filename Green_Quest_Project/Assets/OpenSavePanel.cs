using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSavePanel : MonoBehaviour
{
    public static OpenSavePanel opensavepanel;
    public GameObject painelSave;

    void Awake()
        {
            if(opensavepanel == null)
            {
                opensavepanel = this;

            }else if (opensavepanel != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                painelSave.SetActive(true);
            }
        }
}
