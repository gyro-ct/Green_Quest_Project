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
    private Vector3 pos = Vector3.zero;
    private Vector3 topRightLimit;
    public float Stamina;
    public float Experience;
    public int Level;
    public string areaTransitionName;
    public bool canMove;
    public bool canInteract;
    public bool GotFish;
    public bool FoiContratado;
    public bool FiltroAtivado;
    public bool conversaComEva = false;
    public bool endGame;
    public float lastHorizontal;
    public float lastVertical;
    public bool mybool;
    public bool DesTutorial;
    public bool YAbool;
    public bool YAbool1;
    public bool andando;
    public bool andando2;
    public bool andando3;
    public AudioSource audioSteps;
    public AudioSource audioEmpilha;
    public AudioSource audioEmpilha2;
    
    
    void Start()
    {
        audioSteps.Play(0);
        audioSteps.Pause();
        audioEmpilha.Play(0);
        audioEmpilha.Pause();
        audioEmpilha2.Play(0);
        audioEmpilha2.Pause();
    }
    void Awake()
    {
        mybool = true;
        DesTutorial = true;
    	canMove = true;
        endGame = false;
        canInteract = true;
        YAbool = false;
        YAbool1 = true;
        FiltroAtivado = false;
        GotFish = false;
        Stamina = 100f;
        Experience = 0f;
        Level = 0;
        if (instance == null){
            instance = this;
        }
        else
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
        // Player click space button for item picking
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(animator.GetBool("EsUmaEmpilhadeira")){
                animator.SetBool("EsUmaEmpilhadeira", false);
            } else {
                animator.SetBool("EsUmaEmpilhadeira", true);
            }
            
        }
    
        if(Input.GetKeyDown(KeyCode.Space) && canMove && canInteract)
        {
        	animator.SetTrigger("IsGrabbing");
        	animator.SetBool("IsRunning", false);
        	canMove = false;
        	movement.x = 0.0f;
        	movement.y = 0.0f;
        	animator.SetFloat("Horizontal", movement.x); // set declared blend parameter "Horizontal" as input from keyboard
		    animator.SetFloat("Vertical", movement.y); // same set but vertical
        	StartCoroutine(ExampleCoroutine(0.5f));
        }
        
        // Input
        if (canMove)
        {

            movement.x = Input.GetAxisRaw("Horizontal"); // value from -1 to 1 based on the input of left and right keys of keyboard
            movement.y = Input.GetAxisRaw("Vertical"); // same for up and down keys
            // Debug.Log(movement.x + " " + movement.y);

        } else {
            movement.x = 0.0f;
            movement.y = 0.0f;
        }

        // Player Idle position based on last Input
        if(movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            animator.SetFloat("Last_Horizontal", movement.x);
            if(movement.x == 1 || movement.x == -1){
                lastHorizontal = movement.x;
                lastVertical = 0.0f;
            }
            animator.SetFloat("Last_Vertical", movement.y);
            if(movement.y == 1 || movement.y == -1){
                lastHorizontal = 0.0f;
                lastVertical = movement.y;
            }
        }
        
        
        
        if(movement.x > 0.1 || movement.y > 0.1 || movement.x < -0.1 || movement.y < -0.1)
        {
            animator.SetBool("IsRunning", true);
        } else {
            animator.SetBool("IsRunning", false);          
        }
        andando = animator.GetBool("IsRunning");
        andando2 = animator.GetBool("EsUmaEmpilhadeira");
        andando3 = animator.GetBool("EsUmaEmpilhadeira2");

        if (andando){
            if (andando2 || andando3){
                audioEmpilha.UnPause();
                audioEmpilha2.Pause();
                audioSteps.Pause();
            } else {
                audioSteps.UnPause();
                audioEmpilha.Pause();
                audioEmpilha2.Pause();
            }
        } else {
            if (andando2 || andando3){
                audioEmpilha.Pause();
                audioEmpilha2.UnPause();
                audioSteps.Pause();
            } else {
                audioSteps.Pause();
                audioEmpilha2.Pause();
                audioEmpilha.Pause();
            }
        }
        
        Debug.Log("andando é = " + andando);
     
        
        // Set animation using input
        animator.SetFloat("Horizontal", movement.x); // set declared blend parameter "Horizontal" as input from keyboard
        animator.SetFloat("Vertical", movement.y); // same set but vertical
        animator.SetFloat("Speed", movement.sqrMagnitude); // set Speed as the magnitude of the movement vector (sqr for it to be always positive)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

        //public bool andando = animator.SetBool("IsRunning", true)
        
        

    }
    
    public void startCo(float time){
        StartCoroutine(ExampleCoroutine2(time));
    }
    public void startCo2(float time){
        StartCoroutine(ExampleCoroutine(time));
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
    
    // Call when fishing
    void OnTriggerStay2D(Collider2D col){
        //Debug.Log("TRIGGER "+col.gameObject.tag);
        if (col.gameObject.tag == "Peixe"){
            GotFish = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        //Debug.Log("TRIGGEREXIT "+col.gameObject.tag);
        if (col.gameObject.tag == "Peixe"){
            GotFish = false;
        }
    }

    // Call when collision is happening, here to check collision with movable objects
    void OnCollisionStay2D(Collision2D col)
    {
    
    	//Debug.Log(col.gameObject.tag);
    
    	if (col.gameObject.tag == "Movables")
    	{
    		if (animator.GetBool("IsMovingObject") == false)
    		{
    			animator.SetBool("IsMovingObject", true);
    			//Debug.Log("1" + animator.GetBool("IsMovingObject"));
    		}
    		
    		//Debug.Log("2" + Mathf.Abs(movement.x) + "   " + Mathf.Abs(movement.y));
    		if(Mathf.Abs(movement.x) < 0.1 && Mathf.Abs(movement.y) < 0.1)
		{
			animator.SetBool("IsMovingObject", false);
		}
        
    		
    	}
    }
    
    // Call when collision finishes, here to check collision with movable objects
    void OnCollisionExit2D(Collision2D col)
    {
        //Debug.Log("EXIT" + col.gameObject.tag);
    	if (col.gameObject.tag == "Movables")
    	{
	    animator.SetBool("IsMovingObject", false);
	    }
    }
    
    IEnumerator ExampleCoroutine2(float time)
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    IEnumerator ExampleCoroutine(float time)
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        
        canMove = true;
    }

    public void C2(){
        StartCoroutine(ExampleCoroutinef(0.5f));
    }

    IEnumerator ExampleCoroutinef(float time)
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        
        canMove = false;
    }

    public void C3(){
        StartCoroutine(ExampleCoroutineEV(17.0f));
    }
    IEnumerator ExampleCoroutineEV(float time)
    {
        yield return new WaitForSeconds(time);

        destroyeverything.instance.DestroyEveryInstance();
        
    }

    public void CantMoveMenu()
    {
        movement.x = 0.0f;
        movement.y = 0.0f;
    }

    public void CanMoveMenu()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void JustCanMove()
    {
        canMove = true;
    }
}
