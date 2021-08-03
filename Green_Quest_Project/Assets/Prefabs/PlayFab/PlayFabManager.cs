using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField emailInput; // Tem que ser um email
    public TMP_InputField passInput;
    public TMP_InputField RAInput;

    public void RegisterButton(){

        if (passInput.text.Length >= 6){
            if (RAInput.text.Length == 7){
                var request = new RegisterPlayFabUserRequest{
                    Email = emailInput.text,
                    Password = passInput.text,
                    Username = RAInput.text
                };
                PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
            } else {
                messageText.text = "Invalid RA";
                return;
            }

        } else {
            messageText.text = "Password too short";
            return;
        }

        
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        messageText.text = "Registered and logged in!";
        SaveDummyFunc();
    }

    public void LoginButton(){
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passInput.text
        };
        //TODO add check for RAInput.text
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result){
        messageText.text = "Logged In!";
        Debug.Log("Successful login/account create!");
        SaveDummyFunc();
    }

    public void ResetPasswordButton(){
        var request = new SendAccountRecoveryEmailRequest{
            Email = emailInput.text,
            TitleId = "E1113"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    void OnPasswordReset(SendAccountRecoveryEmailResult result){
        messageText.text = "Password reset mail sent";
    }

    void SaveDummyFunc(){

        // Qatch out for assynchronous call doubled
        SaveLoadQuitGame.saveLoadQuitGame.Save();

        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Nome", RAInput.text}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }
    void OnDataSend(UpdateUserDataResult result){
        Debug.Log("Data sent successfuly");
        LoadDummyFunc();
    }

    void LoadDummyFunc(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }
    void OnDataReceived(GetUserDataResult result){
        Debug.Log("Received user data");
        if (result.Data != null && result.Data.ContainsKey("Nome")){
            Debug.Log(result.Data["Nome"].Value);
        } else {
            Debug.Log("Player data not complete");
        }
        // Talvez adicionar animação
        callScene();
    }

    void callScene(){
        SceneManager.LoadScene("BedroomScene");
    }

    void Start()
    {
        // Login();
    }

    /*void Login()
    {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result){
        Debug.Log("Success");
    }*/

    void OnError(PlayFabError error){
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());

        messageText.text = error.ErrorMessage;

    }
}
