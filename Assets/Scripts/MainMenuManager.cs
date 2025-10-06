using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    //sytax of functions:
    // Return type FunctionName(ParameterType parameterName, ...) { function body... }
    //public means the function can be accessed from other scripts
    //void means the function does not return any value
    // StartGame is the name of the function
    // () means the function does not take any parameters
    // {} contains the body of the function
    //API stands for Application Programming Interface

    public void startGame()
    {
        // SceneManager is an api that allows you to manage scenes in Unity
        //Loadscene is a function that loads a scene by its name or index
        SceneManager.LoadScene("Game");
        Debug.Log("Game Started");      
    }

}
