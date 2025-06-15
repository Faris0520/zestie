using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void RetryLevel()
    {
        Debug.Log("Tombol Restart Diklik!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
