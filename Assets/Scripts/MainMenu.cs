using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// Scene List
    ///  Look to build settings under "File" tab in unity
    ///  0: Main Menu
    ///  1: Tutorial
    ///  2: Play Level 1
    ///  3: Assessment
    public void PlayTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayAssessment()
    {
        SceneManager.LoadScene(3);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
