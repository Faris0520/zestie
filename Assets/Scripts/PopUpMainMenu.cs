using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PopUpMainMenu : MonoBehaviour
{
    public GameObject blurBackground;
    public List<GameObject> popups;
    public Button nextButton;
    public Button prevButton;
    public Button exitButton;

    public float fadeDuration = 0.5f;

    private int currentIndex = 0;

    private void Start()
    {
        // Awal: semua popup nonaktif
        foreach (var popup in popups)
        {
            popup.SetActive(false);
        }
        blurBackground.SetActive(false);

        nextButton.onClick.AddListener(ShowNext);
        prevButton.onClick.AddListener(ShowPrevious);
        exitButton.onClick.AddListener(ClosePopup);

        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void OpenPopup()
    {
        blurBackground.SetActive(true);
        nextButton.gameObject.SetActive(true);
        prevButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        currentIndex = 0;
        ShowCurrentPopup();
    }

    void ShowCurrentPopup()
    {
        for (int i = 0; i < popups.Count; i++)
        {
            popups[i].SetActive(i == currentIndex);
            CanvasGroup group = popups[i].GetComponent<CanvasGroup>();
            if (group != null) group.alpha = (i == currentIndex) ? 1f : 0f;
        }

        // Disable button jika di batas
        prevButton.interactable = currentIndex > 0;
        nextButton.interactable = currentIndex < popups.Count - 1;
    }

    void ShowNext()
    {
        if (currentIndex < popups.Count - 1)
        {
            currentIndex++;
            ShowCurrentPopup();
        }
    }

    void ShowPrevious()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ShowCurrentPopup();
        }
    }

    void ClosePopup()
    {
        foreach (var popup in popups)
        {
            popup.SetActive(false);
        }
        blurBackground.SetActive(false);
        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }
}
