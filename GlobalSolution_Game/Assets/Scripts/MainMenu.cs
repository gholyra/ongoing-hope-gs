using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("MainSceneTest");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }

}
