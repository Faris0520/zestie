using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackFromGame : MonoBehaviour
{
    public Button Backbutton;

    void Start()
    {
        Backbutton.onClick.AddListener(() => SceneManager.LoadScene("MenuLevel"));
    }

}
