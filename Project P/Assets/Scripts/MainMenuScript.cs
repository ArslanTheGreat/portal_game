using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {

        SceneManager.LoadSceneAsync("SampleScene");

    } // StartGame() method

    public void QuitGame() { 

        Application.Quit();  // this function call is ignored in the Editor. To test, make a build

    } // QuitGame() method
}
