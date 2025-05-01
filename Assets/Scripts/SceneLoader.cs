using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISceneLoader
{
    void LoadScene(int buildIndex);
    void Quit();
}

public class UnitySceneLoader : ISceneLoader
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}