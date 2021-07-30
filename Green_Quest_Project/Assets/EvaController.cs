using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class EvaController : MonoBehaviour
{
    public static EvaController instance;

    public int modeWalk = 0;
    public int walking = 0;
    public bool start = true;

    public Transform targetA1;
    public Transform targetA2;
    public Transform target10;
    public Transform target11;
    public Transform target31;
    public Transform target32;
    public Transform target41;
    public Transform target51;
    public Transform target52;
    public Transform target61;
    public Transform target62;
    public Transform target71;
    public Transform target72;
    public Transform target81;
    public Transform target82;
    public Transform target91;
    public Transform target92;
    public Transform target93;
    public Transform target100;
    public Transform target111;
    public Transform target121;
    public Transform target122;
    public Transform target123;
    public Transform target124;

    public Transform AE1;
    public Transform AE2;

    public Animator animator;

    public float smoothTime = 10;

    public string LAYER_NAME = "Background";
    public int sortingOrder = 10;
    private SpriteRenderer sprite;

    public bool PlayerNear = false;
    public bool change = false;

    public bool ativarConversa = true;
    
    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        QuestManager.questManager.PrgInstances.Add(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() {

        // Debug.Log("POSITION" + PlayerController.instance.transform.position.y + " and " + sprite.transform.position.y);

        if (PlayerController.instance.transform.position.y < transform.position.y && LAYER_NAME == "Player")
        {
            change = true;
            sortingOrder = 10;
            LAYER_NAME = "Background";
        } else if (PlayerController.instance.transform.position.y >= transform.position.y && LAYER_NAME == "Background") {
            change = true;
            sortingOrder = 10;
            LAYER_NAME = "Player";
        }

        if (change){
            Debug.Log("CHANGE ACTIVATED");
            sprite.sortingOrder = sortingOrder;
            sprite.sortingLayerName = LAYER_NAME;
            change = false;   
        }
        

    }

    void Update() {        


        //1 Direção, modeWalk, mudar direção na parada?, para qual?
        if (modeWalk == 1 && start){start=false;walk();}
        if (modeWalk == 1 && transform.position == target10.position){stopMovement("L", 2, false, "");}

        if (modeWalk == 3 && transform.position == target31.position){stopMovement("R", 4, false, "");}
        if (modeWalk == 4 && transform.position == target32.position){stopMovement("U", 5, true, "D");}

        if (modeWalk == 6 && transform.position == target41.position){stopMovement("D", 7, true, "U");}

        if (modeWalk == 8 && transform.position == target51.position){stopMovement("R", 9, false, "");}
        if (modeWalk == 9 && transform.position == target52.position){stopMovement("U", 10, true, "D");}

        if (modeWalk == 11 && transform.position == target61.position){stopMovement("D", 12, false, "");}
        if (modeWalk == 12 && transform.position == target62.position){stopMovement("R", 13, true, "U");}

        if (modeWalk == 14 && transform.position == target71.position){stopMovement("D", 15, false, "");}
        if (modeWalk == 15 && transform.position == target72.position){stopMovement("L", 16, true, "U");}

        if (modeWalk == 17 && transform.position == target81.position){stopMovement("D", 18, false, "");}
        if (modeWalk == 18 && transform.position == target82.position){stopMovement("R", 19, true, "U");}//ConversationManager.Instance.StartConversation(conv1);}

        if (modeWalk == 20 && transform.position == target91.position){stopMovement("U", 21, false, "");}
        if (modeWalk == 21 && transform.position == target92.position){stopMovement("R", 22, false, "");}
        if (modeWalk == 22 && transform.position == target93.position){stopMovement("U", 23, false, "");}//ConversationManager.Instance.StartConversation(conv2);}
        if (modeWalk == 23 && transform.position == target111.position){stopMovement("R", 24, true, "D");}

        if (modeWalk == 25 && transform.position == target121.position){stopMovement("L", 26, false, "");}
        if (modeWalk == 26 && transform.position == target122.position){stopMovement("D", 27, false, "");}
        if (modeWalk == 27 && transform.position == target123.position){stopMovement("L", 28, false, "");}
        if (modeWalk == 28 && transform.position == target124.position){stopMovement("D", 29, true, "D");}

        if (modeWalk == 28 && walking == 0 && PlayerNear && Input.GetKeyDown(KeyCode.Space) && ativarConversa){
            QuestManager.questManager.AddQuestItem("Conhecer a empresa", 1);
            ativarConversa = false;
            PlayerController.instance.C2();
            PlayerController.instance.canInteract = false;
            Debug.Log("Antes da conversa");
            atvConv.instance.ativarConversa(1);
            //ConversationManager.Instance.StartConversation(conv1);
            Debug.Log("Depois da conversa");
            // Apróxima é ativada ao se usar o item café
        }

        if (modeWalk == 29 && transform.position == targetA1.position){stopMovement("D", 30, false, "");}
        if (modeWalk == 30 && transform.position == targetA2.position){stopMovement("L", 31, true, "D");}

        if (modeWalk == 31 && PlayerNear && Input.GetKeyDown(KeyCode.Space)){
            atvConv.instance.ativarConversa(2);
            //ConversationManager.Instance.StartConversation(conv2);
        }

        if (modeWalk == 32 && PlayerNear && Input.GetKeyDown(KeyCode.Space)){
            atvConv.instance.ativarConversa(4);
            //ConversationManager.Instance.StartConversation(conv2);
        }

        //3 if (walk value) Target to go
        if (walking == 1){walkg(target10);}
        if (walking == 2){walkg(target11);} // AE1

        if (walking == 3){walkg(target31);}
        if (walking == 4){walkg(target32);}

        if (walking == 6){walkg(target41);}

        if (walking == 8){walkg(target51);}
        if (walking == 9){walkg(target52);}

        if (walking == 11){walkg(target61);}
        if (walking == 12){walkg(target62);}

        if (walking == 14){walkg(target71);}
        if (walking == 15){walkg(target72);}

        if (walking == 17){walkg(target81);}
        if (walking == 18){walkg(target82);}

        if (walking == 20){walkg(target91);}
        if (walking == 21){walkg(target92);}
        if (walking == 22){walkg(target93);}
        if (walking == 23){walkg(target111);}

        if (walking == 25){walkg(target121);}
        if (walking == 26){walkg(target122);}
        if (walking == 27){walkg(target123);}
        if (walking == 28){walkg(target124);} // AE2

        if (walking == 29){walkg(targetA1);}
        if (walking == 30){walkg(targetA2);}
    }

    public void walk(){

        //2 if (update value) walking, parar?, para onde mover?
        if (modeWalk == 1){movement(1, "ML");}
        if (modeWalk == 2){movement(2, "MU");}

        if (modeWalk == 3){movement(3, "MR");}
        if (modeWalk == 4){movement(4, "MU");}

        if (modeWalk == 6){movement(6, "MD");}

        if (modeWalk == 8){movement(8, "MR");}
        if (modeWalk == 9){movement(9, "MU");}

        if (modeWalk == 11){movement(11, "MD");}
        if (modeWalk == 12){movement(12, "MR");}

        if (modeWalk == 14){movement(14, "MD");}
        if (modeWalk == 15){movement(15, "ML");}
        
        if (modeWalk == 17){movement(17, "MD");}
        if (modeWalk == 18){movement(18, "MR");}

        if (modeWalk == 20){movement(20, "MU");}
        if (modeWalk == 21){movement(21, "MR");}
        if (modeWalk == 22){movement(22, "MU");}
        if (modeWalk == 23){movement(23, "MR");}

        if (modeWalk == 25){movement(25, "ML");}
        if (modeWalk == 26){movement(26, "MD");}
        if (modeWalk == 27){movement(27, "ML");}
        if (modeWalk == 28){movement(28, "MD");}

        if (modeWalk == 29){movement(29, "MD");}
        if (modeWalk == 30){movement(30, "ML");}
    }

    public void movement(int walkg, string moveDir){
        walking = walkg;
        animator.SetBool(moveDir, true);
        Debug.Log("NEW "+moveDir);
    }

    public void stopMovement(string dir, int mW, bool changeDir, string dir2){
        Debug.Log("1");
        animator.SetBool("M"+dir, false);
        Debug.Log("OUT M"+dir);
        if (changeDir){
            animator.SetBool("M"+dir2, true);
            Debug.Log("SI M"+dir2);
            animator.SetBool("I"+dir2, true);
            Debug.Log("SI I"+dir2);
        }
        modeWalk = mW;
        walk();
    }

    public void resetBool(){
        animator.SetBool("MD", false);
        animator.SetBool("ID", false);
        animator.SetBool("MU", false);
        animator.SetBool("IU", false);
        animator.SetBool("ML", false);
        animator.SetBool("IL", false);
        animator.SetBool("MR", false);
        animator.SetBool("IR", false);
    }

    public void walkg(Transform target){
        transform.position = Vector3.MoveTowards(transform.position, target.position, 
            smoothTime*Time.deltaTime);
    }

    public void nextMove(bool go){
        modeWalk = modeWalk + 1;
        if (go){
            resetBool();
            walk();
        }
    }

    public void toAE(int mode){
        if (mode == 1){
            transform.position = AE1.position;
            animator.SetBool("ID", true);
            walking = 0;
        } else if (mode == 2){
            transform.position = AE2.position;
            animator.SetBool("ID", true);
            walking = 0;
        }
        
    }

    public void deactivate(){
        gameObject.SetActive(false);
    }
    public void activate(){
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            PlayerNear = true;
        }        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            PlayerNear = false;
        }        
    }

}
