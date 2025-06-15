using UnityEngine;
using UnityEngine.Video;

public class HealthUpEffect : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float displayDuration = 2f; // seconds
    private float timer = 0f;

    private void OnEnable()
    {
        videoPlayer.Play();
        timer = displayDuration;
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.unscaledDeltaTime;
            if (timer <= 0f)
            {
                videoPlayer.Stop();
                gameObject.SetActive(false);
            }
        }
    }
}
