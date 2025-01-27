using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton instance
    public AudioSource backgroundMusic; // Arka plan müziği kaynağı
    [Range(0f, 1f)] public float masterVolume = 1.0f; // Master ses seviyesi

    void Awake()
    {
        // Eğer başka bir AudioManager varsa, bu nesneyi yok et
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Singleton oluştur ve sahneler arasında yok edilmesini engelle
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(float volume)
    {
        masterVolume = volume; // Master volume'ü güncelle
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = masterVolume; // Arka plan müziği için uygula
        }
    }
    public void ApplyVolumeToSource(AudioSource source)
    {
        if (source != null)
        {
            source.volume = masterVolume * source.volume; // Master volume'u uygula
        }
    }
}
