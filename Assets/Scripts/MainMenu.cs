using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public bool DEBUG = false;

    public void NewGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame (){
        if (DEBUG)
        {
            Debug.Log("Quit");
        }               
        Application.Quit();
    }

}
