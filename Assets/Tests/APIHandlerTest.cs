using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class APIHandlerTest
{
    private APIHandler handler;
    private string testName;
    private string testEmail;
    private string testPass;
    private GameObject testObject;

    [SetUp]
    public void Setup()
    {
        testName = "Henry";
        testEmail = "henry@gmail.com";
        testPass = "contraseñaDeHenry";
        
        testObject = new GameObject("TestAPIHandler");
        handler = testObject.AddComponent<APIHandler>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(testObject);
    }

    [UnityTest]
    public IEnumerator TestRegister()
    {
        yield return handler.StartCoroutine(handler.Register(testEmail, testPass, testName));
        Assert.IsTrue(handler.registerSuccess);
    }

    [UnityTest]
    public IEnumerator TestLogin()
    {
        yield return handler.StartCoroutine(handler.Login(testEmail, testPass));
        Assert.IsTrue(handler.loginSuccess);
    }
}