using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsBehav : MonoBehaviour
{
    // Orden de las escenas
    // 0 - Main menu 
    // 1 - UV01
    // 2 - CatMenu
    // 3 - OrgMenu
    // 4 - Login
    // 5 - UV02
    // 6 - UV03
    // 7 - CultMenu
    // 8 - SJU01
    
    // Ir al menú principal
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }

    // Ir al inicio del recorrido de la UV
    public void GoToUV01()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    // Ir al menú de categorías
    public void GoToCatMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex:2);
    }

    // Ir al menú de la categoría "Organización"
    public void GoToOrgMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex:3);
    }
    
    // Ir al login
    public void GoToLogin()
    {
        SceneManager.LoadScene(sceneBuildIndex:4);
    }
    
    // Ir a UV02
    public void GoToUV02()
    {
        SceneManager.LoadScene(sceneBuildIndex:5);
    }
    
    // Ir a UV03
    public void GoToUV03()
    {
        SceneManager.LoadScene(sceneBuildIndex:6);
    }
    
    // Ir al menú cultural
    public void GoToCultMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex:7);
    }
    
    // Ir a SJU01
    public void GoToSJU01()
    {
        SceneManager.LoadScene(sceneBuildIndex:8);
    }

    // Ir a menú de educación
    public void GoToEdMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex:9);
    }
    
    // Ir a ED01
    public void GoToED01()
    {
        SceneManager.LoadScene(sceneBuildIndex:10);
    }
    
    // Salir del programa
    public void ExitProgram()
    {
        Application.Quit();
    }
}
