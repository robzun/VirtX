using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIHandler : MonoBehaviour
{
    // http://localhost:8080/api/login
    // https://virtx-api-production.up.railway.app/api/login
    // https://virtx-api.onrender.com/api/login
    public string testName;
    public string testEmail;
    public string testPassword;
    public InputField nameInput;
    public InputField mailInput;
    public InputField passwordInput;
    public GameObject errorMsg;

    public void SendLoginData()
    {
        string mail = mailInput.text;
        string password = passwordInput.text;
        StartCoroutine(Login(mail, password));
    }

    public void SendRegisterData()
    {
        string mail = mailInput.text;
        string password = passwordInput.text;
        string name = nameInput.text;
        StartCoroutine(Register(mail, password, name));
    }
    
    [System.Serializable]
    public class LoginData
    {
        public string email;
        public string password;

        public LoginData(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
    
    [System.Serializable]
    public class RegisterData
    {
        public string email;
        public string password;
        public string name;

        public RegisterData(string email, string password, string name)
        {
            this.email = email;
            this.password = password;
            this.name = name;
        }
    }
    
    [ContextMenu("Test Login")]
    public void TestLogin()
    {
        StartCoroutine(Login(testEmail, testPassword));
    }

    [ContextMenu("Test Register")]
    public void TestRegister()
    {
        StartCoroutine(Register(testEmail, testPassword, testName));
    }
    
    // Post login
    IEnumerator Login(string email, string password)
    {
        var loginData = new LoginData(email, password);
        string json = JsonUtility.ToJson(loginData);

        UnityWebRequest request = new UnityWebRequest("https://virtx-api.onrender.com/api/login", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Login success: " + request.downloadHandler.text);
            ButtonsBehav.GoToCatMenu();
        }
        else
        {
            Debug.LogError("Login failed");
            errorMsg.SetActive(true);
        }
    }
    
    // Post Register
    IEnumerator Register(string email, string password, string name)
    {
        var registerData = new RegisterData(email, password, name);
        string json = JsonUtility.ToJson(registerData);

        UnityWebRequest request = new UnityWebRequest("https://virtx-api.onrender.com/api/register", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Register success: " + request.downloadHandler.text); 
            ButtonsBehav.GoToCatMenu();
        }
        else
        {
            Debug.LogError("Register failed: " + request.error);
            errorMsg.SetActive(true);
        }
    }
}
