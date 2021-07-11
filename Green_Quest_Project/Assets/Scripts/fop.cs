using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class fop : MonoBehaviour
{
    private string LAYER_NAME;
    public int sortingOrder_Back;
    public int sortingOrder_PGT;
    private int sortingOrder;
    private TilemapRenderer sprite;

    public float height;

    private bool change = false;

    void Start()
    {
        
        sprite = GetComponent<TilemapRenderer>();
        Debug.Log("SPRITE");
        LAYER_NAME = "Player";
    }

    void FixedUpdate() {

        // Debug.Log("POSITION" + PlayerController.instance.transform.position.y + " and " + sprite.transform.position.y);

        if (PlayerController.instance.transform.position.y < height && LAYER_NAME == "Player")
        {
            change = true;
            Debug.Log("ENTERED FOP");
            sortingOrder = sortingOrder_Back;
            LAYER_NAME = "Background";
        } else if (PlayerController.instance.transform.position.y >= height && LAYER_NAME == "Background") {
            change = true;
            sortingOrder = sortingOrder_PGT;
            LAYER_NAME = "Player";
        }

        if (change){
            Debug.Log("CHANGE ACTIVATED");
            sprite.sortingOrder = sortingOrder;
            sprite.sortingLayerName = LAYER_NAME;
            change = false;   
        }
        

    }
}
