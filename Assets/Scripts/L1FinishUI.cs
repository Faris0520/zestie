using UnityEngine;
using System.Collections;

public class FinishTriggerUI : MonoBehaviour
{
    public GameObject finishGreatPopup;       // Jika health 100
    public GameObject finishMustRestartPopup; // Jika < 100
    public GameObject blurBackground;

    public float fadeDuration = 1f;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip mustRestartSound;
    [SerializeField] private AudioClip greatFinishSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health health = other.GetComponent<Health>();
            if (health == null) return;

            bool isGreat = health.currentHealth == 100f;
            GameObject popupToShow = isGreat ? finishGreatPopup : finishMustRestartPopup;

            // Aktifkan GameObject
            blurBackground.SetActive(true);
            popupToShow.SetActive(true);

            // Ambil CanvasGroup
            CanvasGroup blurGroup = blurBackground.GetComponent<CanvasGroup>();
            CanvasGroup popupGroup = popupToShow.GetComponent<CanvasGroup>();

            // Atur agar blur tidak menghalangi klik, popup bisa di-klik
            if (blurGroup != null)
            {
                blurGroup.alpha = 0f;
                blurGroup.blocksRaycasts = false;
                blurGroup.interactable = false;
                StartCoroutine(FadeIn(blurGroup, fadeDuration));
            }
            if (popupGroup != null)
            {
                popupGroup.alpha = 0f;
                popupGroup.blocksRaycasts = true;
                popupGroup.interactable = true;
                StartCoroutine(FadeIn(popupGroup, fadeDuration));
            }

            // Mainkan suara sesuai popup
            if (audioSource != null)
            {
                if (isGreat && greatFinishSound != null)
                    audioSource.PlayOneShot(greatFinishSound);
                else if (!isGreat && mustRestartSound != null)
                    audioSource.PlayOneShot(mustRestartSound);
            }
        }
    }

    public void ShowMustRestartPopup()
    {
        blurBackground.SetActive(true);
        finishMustRestartPopup.SetActive(true);

        CanvasGroup blurGroup = blurBackground.GetComponent<CanvasGroup>();
        CanvasGroup popupGroup = finishMustRestartPopup.GetComponent<CanvasGroup>();

        if (blurGroup != null)
        {
            blurGroup.alpha = 0f;
            blurGroup.blocksRaycasts = false;
            blurGroup.interactable = false;
            StartCoroutine(FadeIn(blurGroup, fadeDuration));
        }
        if (popupGroup != null)
        {
            popupGroup.alpha = 0f;
            popupGroup.blocksRaycasts = true;
            popupGroup.interactable = true;
            StartCoroutine(FadeIn(popupGroup, fadeDuration));
        }

        if (mustRestartSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(mustRestartSound);
        }
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(time / duration);
            yield return null;
        }
    }
}
