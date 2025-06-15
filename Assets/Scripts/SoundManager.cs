using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public Image soundButtonImage;

    private bool isMuted;

    private void Start()
    {
        // Cegah duplikat SoundManager saat kembali ke main menu
        int count = FindObjectsOfType<SoundManager>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    
}

public void ToggleSound()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
        UpdateSound();
    }

    private void UpdateSound()
    {
        musicSource.mute = isMuted;
        soundButtonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }
}
