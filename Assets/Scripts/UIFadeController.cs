using UnityEngine;
using System.Collections;

public class UIFadeController : MonoBehaviour
{
    public static UIFadeController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowWithFade(GameObject obj, float fadeDuration)
    {
        obj.SetActive(true);
        CanvasGroup group = obj.GetComponent<CanvasGroup>();
        if (group != null)
        {
            group.alpha = 0f;
            StartCoroutine(FadeIn(group, fadeDuration));
        }
    }

    private IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(time / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}
