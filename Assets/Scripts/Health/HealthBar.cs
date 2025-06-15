using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image healthImage;
    //[SerializeField] private Image totalhealthBar;
    //[SerializeField] private Image currenthealthBar;
    [SerializeField] private GameObject image0;
    [SerializeField] private GameObject image25;
    [SerializeField] private GameObject image50;
    [SerializeField] private GameObject image75;
    [SerializeField] private GameObject image100;


    private void Update()
    {
        float health = playerHealth.currentHealth;

        image0.SetActive(false);
        image25.SetActive(false);
        image50.SetActive(false);
        image75.SetActive(false);
        image100.SetActive(false);

        if (health >= 100)
            image100.SetActive(true);
        else if (health >= 75)
            image75.SetActive(true);
        else if (health >= 50)
            image50.SetActive(true);
        else if (health >= 25)
            image25.SetActive(true);
        else if (health >= 0)
            image0.SetActive(true);
    }
}