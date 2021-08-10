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
        SceneManager.LoadScene("BedroomScene");
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
    void OnError(PlayFabError error){
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());

        messageText.text = error.ErrorMessage;

    }
}
