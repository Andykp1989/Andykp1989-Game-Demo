using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //When the Play button is clicked, load the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    //When the Quit button is clicked, quit the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting...");
    }

}
