using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class LoginRegister : MonoBehaviour
{
    void Start ()
    {
        string username = "TestUser";
        string password = "password1";

        RegisterPlayFabUserRequest registerRequest = new RegisterPlayFabUserRequest
        {
            Username = username,
            DisplayName = username,
            Password = password,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(registerRequest,
            result =>
            {
                Debug.Log(result.PlayFabId);
            },
            error =>
            {
                Debug.Log(error.ErrorMessage);
            }
            );
    }
}