using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsBehav : MonoBehaviour
{
    public static ISceneLoader sceneLoader = new UnitySceneLoader();

    // 0 - Main menu 
    public static void GoToMainMenu() => sceneLoader.LoadScene(0);

    // 1 - UV01
    public static void GoToUV01() => sceneLoader.LoadScene(1);

    // 2 - CatMenu
    public static void GoToCatMenu() => sceneLoader.LoadScene(2);

    // 3 - OrgMenu
    public static void GoToOrgMenu() => sceneLoader.LoadScene(3);

    // 4 - Login
    public static void GoToLogin() => sceneLoader.LoadScene(4);

    // 5 - UV02
    public static void GoToUV02() => sceneLoader.LoadScene(5);

    // 6 - UV03
    public static void GoToUV03() => sceneLoader.LoadScene(6);

    // 7 - CultMenu
    public static void GoToCultMenu() => sceneLoader.LoadScene(7);

    // 8 - SJU01
    public static void GoToSJU01() => sceneLoader.LoadScene(8);

    // Exit app
    public static void ExitProgram() => sceneLoader.Quit();
}