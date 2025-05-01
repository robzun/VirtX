using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIHandler : MonoBehaviour
{
    // http://localhost:8080/api/login
    // http://virtx-api-production.up.railway.app/api/login
    public string testName;
    public string testEmail;
    public string testPassword;
    public InputField nameInput;
    public InputField mailInput;
    public InputField passwordInput;
    public GameObject errorMsg;
    public bool loginSuccess;
    public bool registerSuccess;

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
    public IEnumerator Login(string email, string password)
    {
        if (errorMsg == null)
        {
            errorMsg = new GameObject();
        }
        
        var loginData = new LoginData(email, password);
        string json = JsonUtility.ToJson(loginData);

        UnityWebRequest request = new UnityWebRequest("http://localhost:8080/api/login", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Login success: " + request.downloadHandler.text);
            ButtonsBehav.GoToCatMenu();
            loginSuccess = true;
        }
        else
        {
            //Debug.LogError("Login failed: " + request.error);
            errorMsg.SetActive(true);
            loginSuccess = false;
        }
    }

    // Post Register
    public IEnumerator Register(string email, string password, string name)
    {
        if (errorMsg == null)
        {
            errorMsg = new GameObject();
        }
        
        var registerData = new RegisterData(email, password, name);
        string json = JsonUtility.ToJson(registerData);

        UnityWebRequest request = new UnityWebRequest("http://localhost:8080/api/register", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Register success: " + request.downloadHandler.text);
            ButtonsBehav.GoToCatMenu();
            registerSuccess = true;
        }
        else
        {
            //Debug.LogError("Register failed: " + request.error);
            errorMsg.SetActive(true);
            registerSuccess = false;
        }
    }
}