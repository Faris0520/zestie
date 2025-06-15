using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaPopupManager : MonoBehaviour
{
    public GameObject blurBackground;

    public GameObject mainEncyclopediaPopup; // "ens"
    public GameObject encyclopedia1Popup;
    public GameObject encyclopedia2Popup;
    public GameObject encyclopedia3Popup;
    public GameObject encyclopedia4Popup;
    public GameObject encyclopedia5Popup;
    public GameObject encyclopedia6Popup; // "ensiklopedia1"

    public Button openEncyclopediaButton;     // tombol "EnsiklopediaButton" di Main Menu
    public Button ens1Button;
    public Button ens2Button;
    public Button ens3Button;
    public Button ens4Button;
    public Button ens5Button;
    public Button ens6Button; // (tidak dipakai di contoh ini, bisa ditambah)
    public Button exitMainPopupButton;

    public Button backFromEncyclopedia1Button;
    public Button backFromEncyclopedia2Button;
    public Button backFromEncyclopedia3Button;
    public Button backFromEncyclopedia4Button;
    public Button backFromEncyclopedia5Button;
    public Button backFromEncyclopedia6Button;

    void Start()
    {
        // Sembunyikan semua di awal
        mainEncyclopediaPopup.SetActive(false);
        encyclopedia1Popup.SetActive(false);
        encyclopedia2Popup.SetActive(false);
        encyclopedia3Popup.SetActive(false);
        encyclopedia4Popup.SetActive(false);
        encyclopedia5Popup.SetActive(false);
        encyclopedia6Popup.SetActive(false);

        // Listener
        openEncyclopediaButton.onClick.AddListener(ShowMainPopup);
        exitMainPopupButton.onClick.AddListener(HideAllPopups);

        ens1Button.onClick.AddListener(ShowEncyclopedia1);
        ens2Button.onClick.AddListener(ShowEncyclopedia2);
        ens3Button.onClick.AddListener(ShowEncyclopedia3);
        ens4Button.onClick.AddListener(ShowEncyclopedia4);
        ens5Button.onClick.AddListener(ShowEncyclopedia5);
        ens6Button.onClick.AddListener(ShowEncyclopedia6);
        backFromEncyclopedia1Button.onClick.AddListener(BackToMainPopup);
        backFromEncyclopedia2Button.onClick.AddListener(BackToMainPopup);
        backFromEncyclopedia3Button.onClick.AddListener(BackToMainPopup);
        backFromEncyclopedia4Button.onClick.AddListener(BackToMainPopup);
        backFromEncyclopedia5Button.onClick.AddListener(BackToMainPopup);
        backFromEncyclopedia6Button.onClick.AddListener(BackToMainPopup);
    }

    void ShowMainPopup()
    {
        blurBackground.SetActive(true);
        mainEncyclopediaPopup.SetActive(true);
    }

    void HideAllPopups()
    {
        mainEncyclopediaPopup.SetActive(false);
        encyclopedia1Popup.SetActive(false);
        blurBackground.SetActive(false);
    }

    void ShowEncyclopedia1()
    {
        mainEncyclopediaPopup.SetActive(false);
        encyclopedia1Popup.SetActive(true);
    }
    void ShowEncyclopedia2()
    {
        mainEncyclopediaPopup.SetActive(false);
        encyclopedia2Popup.SetActive(true);
    }
    void ShowEncyclopedia3()
    {
        mainEncyclopediaPopup.SetActive(false);
        encyclopedia3Popup.SetActive(true);
    }
    void ShowEncyclopedia4()
    {
        mainEncyclopediaPopup.SetActive(false);
        encyclopedia4Popup.SetActive(true);
    }
    void ShowEncyclopedia5()
    {
        mainEncyclopediaPopup.SetActive(false);
        encyclopedia5Popup.SetActive(true);
    }
    void ShowEncyclopedia6()
    {
        mainEncyclopediaPopup.SetActive(false);
        encyclopedia6Popup.SetActive(true);
    }
    void BackToMainPopup()
    {
        // Set all encyclopedia popups to inactive when returning to main popup
        encyclopedia1Popup.SetActive(false);
        encyclopedia2Popup.SetActive(false);
        encyclopedia3Popup.SetActive(false);
        encyclopedia4Popup.SetActive(false);
        encyclopedia5Popup.SetActive(false);
        encyclopedia6Popup.SetActive(false);
        mainEncyclopediaPopup.SetActive(true);
    }
}
