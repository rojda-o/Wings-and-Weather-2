using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu; // Pause menu panel
    private bool isPaused = false; // Game pause state
    private bool escapePressed = false; // To check if the Escape key is pressed

    void Update()
    {
        // Perform the action only once when the Escape key is pressed
        if (Input.GetAxis("Escape") > 0 && !escapePressed)
        {
            escapePressed = true; // Set this variable to true when the Escape key is pressed

            if (isPaused)
            {
                ResumeGame(); // Close the menu
            }
            else
            {
                PauseGame(); // Open the menu
            }
        }

        // Allow the next press when the Escape key is released
        if (Input.GetAxis("Escape") == 0)
        {
            escapePressed = false; // Allow pressing again when the Escape key is released
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false); // Close the menu
        Time.timeScale = 1f; // Resume the game
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true); // Open the menu
        Time.timeScale = 0.01f; // Pause the game
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene("Main_Menu"); // Return to the main menu
    }
}
