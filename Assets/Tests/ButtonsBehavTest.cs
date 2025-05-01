using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ButtonsBehavTests
{
    private class MockSceneLoader : ISceneLoader
    {
        public int lastSceneIndex = -1;
        public bool quitCalled = false;

        public void LoadScene(int buildIndex)
        {
            lastSceneIndex = buildIndex;
        }

        public void Quit()
        {
            quitCalled = true;
        }
    }

    [Test]
    public void GoToMainMenu_CallsScene0()
    {
        var mockLoader = new MockSceneLoader();
        ButtonsBehav.sceneLoader = mockLoader;

        ButtonsBehav.GoToMainMenu();

        Assert.AreEqual(0, mockLoader.lastSceneIndex);
    }

    [Test]
    public void ExitProgram_CallsQuit()
    {
        var mockLoader = new MockSceneLoader();
        ButtonsBehav.sceneLoader = mockLoader;

        ButtonsBehav.ExitProgram();

        Assert.IsTrue(mockLoader.quitCalled);
    }
}