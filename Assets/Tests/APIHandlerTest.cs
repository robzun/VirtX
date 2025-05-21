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
        testName = "User";
        testEmail = "user@domain.com";
        testPass = "p4$$w0rd";
        
        testObject = new GameObject("TestAPIHandler");
        handler = testObject.AddComponent<APIHandler>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(testObject);
    }

    [UnityTest]
    public IEnumerator TestRegisterSuccess()
    {
        yield return handler.StartCoroutine(handler.Register(testEmail, testPass, testName));
        Assert.IsTrue(handler.registerSuccess);
    }

    [UnityTest]
    public IEnumerator TestRegisterFail()
    {
        yield return handler.StartCoroutine(handler.Register("robzun03@gmail.com", testPass, testName));
        Assert.IsFalse(handler.registerSuccess);
    }
    
    [UnityTest]
    public IEnumerator TestLoginSuccess()
    {
        yield return handler.StartCoroutine(handler.Login("robzun03@gmail.com", "123456789"));
        Assert.IsTrue(handler.loginSuccess);
    }
    
    [UnityTest]
    public IEnumerator TestLoginFail()
    {
        yield return handler.StartCoroutine(handler.Login("error@example.com", "wrongPassword"));
        Assert.IsFalse(handler.loginSuccess);
    }
}