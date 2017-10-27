using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //allows us to switch between scenes

//Add functionality to the buttons
public class MenuManager : MonoBehaviour {

    //function that loads the game level
    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }

    //function that exits the application
    public void ExitGame() {
        Application.Quit();
    }

}
