using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float speed = 5f; // Bird's movement speed
    public int lives = 3; // Starting lives value
    public TMP_Text livesText; // Text to display lives
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator component is missing!");
        }

        // Set lives value based on the scene
        if (SceneManager.GetActiveScene().name == "Scene")
        {
            lives = 3; // Starting value in the first scene
        }
        else
        {
            lives = PlayerPrefs.GetInt("LIVES", 3); // Get saved value in the second scene
        }
        UpdateLivesText();
    }

    void Update()
    {
        // Get horizontal and vertical input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);

        // Prevent the bird from going beyond the screen boundaries
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -7.0f, -4.0f),
            Mathf.Clamp(transform.position.y, 0f, 4.0f), 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SunnyCloud") || other.CompareTag("StormyCloud"))
        {
            HandleCloudCollision(other);
        }
    }

    private void HandleCloudCollision(Collider2D cloud)
    {
        // Play sound and destroy the cloud
        AudioSource cloudAudio = cloud.GetComponent<AudioSource>();
        if (cloudAudio != null)
        {
            // Apply master volume
            AudioManager.instance.ApplyVolumeToSource(cloudAudio);
            
            cloudAudio.spatialBlend = 1.0f; // 3D sound effect
            cloudAudio.Play();
            StartCoroutine(DestroyAfterSound(cloud.gameObject, 1.0f));
        }
        // Reset cloud speed
        Cloud_sc cloudScript = cloud.GetComponent<Cloud_sc>();
        if (cloudScript != null)
        {
            cloudScript.speed = 0; // Reset speed
        }

        if (cloud.CompareTag("SunnyCloud"))
        {
            lives++;
            anim.SetTrigger("OnLiveIncrease");
        }
        else if (cloud.CompareTag("StormyCloud"))
        {
            lives--;
            anim.SetTrigger("OnLiveDecrease");
        }

        UpdateLivesText();

        // If lives == 5 and in the first scene, transition to the second scene
        if (lives == 5 && SceneManager.GetActiveScene().name == "Scene")
        {
            TransitionToSecondScene();
        }

        // If lives < 1, restart the scene
        if (lives < 1)
        {
            Invoke("RestartScene", 1.0f); // Call the function after 1 second
        }

    }

    private void UpdateLivesText()
    {
        livesText.text = "LIVES: " + lives;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    private void TransitionToSecondScene()
    {
        // Save the lives value
        PlayerPrefs.SetInt("LIVES", lives);
        PlayerPrefs.Save();

        // Start async transition
        StartCoroutine(LoadSecondSceneAsync());
    }

    private IEnumerator LoadSecondSceneAsync()
    {
        yield return new WaitForSeconds(1.0f); // Wait for 1 second to finish the sound
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene1", LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator DestroyAfterSound(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
