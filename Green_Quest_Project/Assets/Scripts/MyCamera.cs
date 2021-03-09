using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MyCamera : MonoBehaviour
{
    public Transform target;
    public Tilemap theMap;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    private float halfHeight;
    private float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        //target = PlayerController.instance.transform;
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0.5f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0.5f);
        PlayerController.instance.setBounds(theMap.localBounds.min, theMap.localBounds.max);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);

        //Keep the camera inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
