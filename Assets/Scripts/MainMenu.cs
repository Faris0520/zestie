using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button soundButton;
    public Image soundIcon;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isSoundOn;

    void Start()
    {
        isSoundOn = PlayerPrefs.GetInt("Sound", 1) == 1;
        UpdateSoundIcon();

        playButton.onClick.AddListener(() => SceneManager.LoadScene("MenuLevel"));
        exitButton.onClick.AddListener(() => Application.Quit());
        soundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        PlayerPrefs.SetInt("Sound", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
        UpdateSoundIcon();

        AudioListener.volume = isSoundOn ? 1 : 0;
    }

    void UpdateSoundIcon()
    {
        soundIcon.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
    }
}
