using UnityEngine;
using System.Collections;

public class TriggerPenjelasan : MonoBehaviour
{
    public GameObject popupImage;
    public GameObject blurBackground;
    public float fadeDuration = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            blurBackground.SetActive(true);
            popupImage.SetActive(true);

            UIFadeController.Instance.ShowWithFade(blurBackground, fadeDuration);
            UIFadeController.Instance.ShowWithFade(popupImage, fadeDuration);

            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            if (movement != null)
                movement.enabled = false;

            Destroy(gameObject);
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

        canvasGroup.alpha = 1f; // Pastikan 1.0f
    }

}
