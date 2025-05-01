using NUnit.Framework;
using UnityEngine;

public class ButtonsBehavTests
{
    private class MockSceneLoader : ISceneLoader
    {
        public int? LastSceneIndex { get; private set; }
        public bool QuitCalled { get; private set; } = false;

        public void LoadScene(int buildIndex)
        {
            LastSceneIndex = buildIndex;
        }

        public void Quit()
        {
            QuitCalled = true;
        }
    }

    private MockSceneLoader mockLoader;

    [SetUp]
    public void Setup()
    {
        mockLoader = new MockSceneLoader();
        ButtonsBehav.sceneLoader = mockLoader;
    }

    [Test]
    public void GoToMainMenu_LoadsScene0()
    {
        ButtonsBehav.GoToMainMenu();
        Assert.AreEqual(0, mockLoader.LastSceneIndex);
    }

    [Test]
    public void GoToUV01_LoadsScene1()
    {
        ButtonsBehav.GoToUV01();
        Assert.AreEqual(1, mockLoader.LastSceneIndex);
    }

    [Test]
    public void GoToCatMenu_LoadsScene2()
    {
        ButtonsBehav.GoToCatMenu();
        Assert.AreEqual(2, mockLoader.LastSceneIndex);
    }

    [Test]
    public void GoToOrgMenu_LoadsScene3()
    {
        ButtonsBehav.GoToOrgMenu();
        Assert.AreEqual(3, mockLoader.LastSceneIndex);
    }

    [Test]
    public void GoToLogin_LoadsScene4()
    {
        ButtonsBehav.GoToLogin();
        Assert.AreEqual(4, mockLoader.LastSceneIndex);
    }

    [Test]
    public void GoToUV02_LoadsScene5()
    {
        ButtonsBehav.GoToUV02();
        Assert.AreEqual(5, mockLoader.LastSceneIndex);
    }

    [Test]
    public void GoToUV03_LoadsScene6()
    {
        ButtonsBehav.GoToUV03();
        Assert.AreEqual(6, mockLoader.LastSceneIndex);
    }

    [Test]
    public void GoToCultMenu_LoadsScene7()
    {
        ButtonsBehav.GoToCultMenu();
        Assert.AreEqual(7, mockLoader.LastSceneIndex);
    }

    [Test]
    public void GoToSJU01_LoadsScene8()
    {
        ButtonsBehav.GoToSJU01();
        Assert.AreEqual(8, mockLoader.LastSceneIndex);
    }

    [Test]
    public void ExitProgram_CallsQuit()
    {
        ButtonsBehav.ExitProgram();
        Assert.IsTrue(mockLoader.QuitCalled);
    }
}
