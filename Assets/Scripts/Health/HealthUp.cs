using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered by: {collision.name}, tag: {collision.tag}");
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false); 
        }
    }
}
