using UnityEngine;
using UnityEngine.UI;

public class NotifFullScreen : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject blurBackground;
    public GameObject notifPopup;
    public Button closeButton;

    private void Start()
    {
        // Tampilkan popup di awal
        ShowPopup();

        // Hubungkan event CloseButton
        if (closeButton != null)
            closeButton.onClick.AddListener(HidePopup);
    }

    private void ShowPopup()
    {
        blurBackground.SetActive(true);
        notifPopup.SetActive(true);
    }

    private void HidePopup()
    {
        blurBackground.SetActive(false);
        notifPopup.SetActive(false);
    }
}
