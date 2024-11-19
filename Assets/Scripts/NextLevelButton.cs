using UnityEngine.SceneManagement;
using UnityEngine;

public class NextSceneButton : MonoBehaviour
{
    //This function will be called when the Next button is clicked
    public void LoadNextScene()
    {
        //Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Check if the next scene exists in the build settings
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            //Load the next scene based on the current index
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            //Optionally, loop back to the Main Menu if at the last scene
            SceneManager.LoadScene("MainMenu"); 
        }
    }
}
