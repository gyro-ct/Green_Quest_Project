using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Based on tutorial https://www.youtube.com/watch?v=whzomFgjT50

// Player basics : Edit sprite -> Adjust number of pixels to 64x64 -> Place Idle_down sprite as default on screen ->
// 	Add rigidbody with gravity = 0 and constraint in Z axis for no rotation -> Basic input programming ->
//	Add Animator in Player and set horizontal, vertical and speed parameters -> Create blender tree with 4 motions ->
//	Add transitions from idle to movement (blender tree) without exit time and transition duration -> 
//	Set speed condition on blender tree to below a threshold input -> Animator programming (set parameters of animation
//	with input values)

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f; // Speed in which the player is moving
    public Rigidbody2D playerRBody; // Player rigidbody reference
    public Animator animator; // Player animator object
    Vector2 movement; // Input movement from keyboard
    public static PlayerController instance;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    public string areaTransitionName;
    

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
            
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // As Update is dependent on frame rate, it is better to use FixedUpdate for movement and Update for input handling
        
        // Input
        movement.x = Input.GetAxisRaw("Horizontal"); // value from -1 to 1 based on the input of left and right keys of keyboard
        movement.y = Input.GetAxisRaw("Vertical"); // same for up and down keys
        
        // Set animation using input
        animator.SetFloat("Horizontal", movement.x); // set declared blend parameter "Horizontal" as input from keyboard
        animator.SetFloat("Vertical", movement.y); // same set but vertical
        animator.SetFloat("Speed", movement.sqrMagnitude); // set Speed as the magnitude of the movement vector (sqr for it to be always positive)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
    
    // Update executed in a fixed timer (always 15 times a sec)
    void FixedUpdate()
    {
    	// Movement (set movement using Input)
    	//	Time.fixedDeltaTime is the amount of time elapsed since last function [FixedUpdate] call. It ensures that the speed is always the same
    	playerRBody.MovePosition(playerRBody.position + movement*moveSpeed*Time.fixedDeltaTime); // get the player to a new position based on preset variables
    }
   public void setBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(0.5f,0.5f,0f);
        topRightLimit = topRight + new Vector3(-0.5f,0.5f,0f);
    }
}
