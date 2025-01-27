using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu_sc : MonoBehaviour
{
    public float delay = 2.0f;
    
    //when play button is pressed, load first scene
    public void playGame()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //when exit button is pressed
    public void quitGame()
    {
    StartCoroutine(ReloadSceneWithDelay());
    }

    public void mainMenu()
    {
    SceneManager.LoadScene("Main Menu");
    }
    private IEnumerator ReloadSceneWithDelay()
    {
        yield return new WaitForSeconds(delay);
        // Reloads current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
