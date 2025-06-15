using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button Backbutton;

    void Start()
    {
        Level1.onClick.AddListener(() => SceneManager.LoadScene("Level1"));
        Level2.onClick.AddListener(() => SceneManager.LoadScene("Level 2"));
        Level3.onClick.AddListener(() => SceneManager.LoadScene("Level 3"));
        Backbutton.onClick.AddListener(() => SceneManager.LoadScene("Main Menu"));
    }

}
