using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuButton : MonoBehaviour
{
    public void GoToMenu()
    {
        Debug.Log("Tombol Menu Diklik!");
        SceneManager.LoadScene("Main Menu");
    }
}
