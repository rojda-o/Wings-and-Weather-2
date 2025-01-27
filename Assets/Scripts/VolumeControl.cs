using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Volume control slider

    void Start()
    {
        // Check AudioManager and Slider
        if (AudioManager.instance == null)
        {
            Debug.LogError("AudioManager instance not found!");
            return;
        }

        if (volumeSlider == null)
        {
            Debug.LogError("VolumeSlider not assigned!");
            return;
        }

        // Set the slider's initial value to the current volume level
        volumeSlider.value = AudioManager.instance.backgroundMusic.volume;

        // Listen for changes to the slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetVolume(volume); // Update the volume level
        }
    }
}
