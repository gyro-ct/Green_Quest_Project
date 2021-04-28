using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FishGame : MonoBehaviour
{
    public GameObject Fish;
    public TMP_Text Contador;
    public TMP_Text Message;
    public GameObject ImgOK;
    public GameObject ImgNO;
    public GameObject ButtonStart; 
    public GameObject ButtonStartAgain;
    public GameObject Boia;

    public GameObject Player;
    public static FishGame fishGame;
    public int PeixesPescados = 0;
    public bool HaPeixes = false; 
    public List <GameObject> myList = new List<GameObject>();
    public int Round = 0;

    void Awake()
    {
        if(fishGame == null)
        {
            fishGame = this;

        }else if (fishGame != this)
        {
            Destroy(gameObject);
        }
    }

    void Start(){
        ButtonStart.SetActive(true);
        ButtonStartAgain.SetActive(false);
        Contador.text = PeixesPescados.ToString();
    }

    public void SetButton(bool mybool){
        HaPeixes = mybool;
        //Debug.Log(HaPeixes);
        if(mybool){
            ImgOK.SetActive(mybool);
            ImgNO.SetActive(!mybool);
        } else {
            ImgOK.SetActive(mybool);
            ImgNO.SetActive(!mybool);
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            if (HaPeixes){
                Boia.SetActive(false);
                if(Random.value > 0.7){
                    Debug.Log("Você Pescou!");
                    PeixesPescados = PeixesPescados + 1;
                    Contador.text = PeixesPescados.ToString();
                    Message.text = "Pescou!";
                    if (PeixesPescados == 3){
                        Debug.Log("Terminou");
                        deletePeixesFinal();
                    } else {
                        deletePeixes();
                    }
                } else {
                    Debug.Log("Você Pescou uma bota :(");
                    if(Random.value >= 0.5){
                        deletePeixesAgain("Pescou uma bota!");
                    } else {
                        deletePeixesAgain("Pescou uma peixe com poison!");
                    }
                }
                
            } else {
                Boia.SetActive(false);
                deletePeixesAgain("Você não pescou um peixe!");
            }
        }

    }

    public void deletePeixes(){
        for (int i=0; i<myList.Count; i++){
            Destroy(myList[i]);
        }
        ButtonStart.SetActive(true);
    }
    public void deletePeixesAgain(string message){
        for (int i=0; i<myList.Count; i++){
            Destroy(myList[i]);
        }
        Message.text = message;
        ButtonStartAgain.SetActive(true);
    }
 
    public void deletePeixesFinal(){
        for (int i=0; i<myList.Count; i++){
            Destroy(myList[i]);
        }
        changeAlphaPlayer();
        SceneManager.LoadScene("Fishing");
    }

    void changeAlphaPlayer(){
        Player = GameObject.Find("Player(Clone)").gameObject;
        Player.transform.position = new Vector3(0f, 0f, 0f);
        Color tmp = Player.GetComponent<SpriteRenderer>().color;
        tmp.a = 255f;
        Player.GetComponent<SpriteRenderer>().color = tmp;
    }

    public void startRound(){
        Round = Round + 1;
        Debug.Log(Round);
        Boia.SetActive(true);
        ButtonStart.SetActive(false);
        for(int i=0; i<10*Round;i++){
            GameObject Dfish = Instantiate(Fish);
            Dfish.SetActive(true);
            myList.Add(Dfish);
        }
    }

    public void startRoundAgain(){
        Debug.Log(Round);
        Boia.SetActive(true);
        ButtonStartAgain.SetActive(false);
        for(int i=0; i<10*Round;i++){
            GameObject Dfish = Instantiate(Fish);
            Dfish.SetActive(true);
            myList.Add(Dfish);
        }
    }

}
