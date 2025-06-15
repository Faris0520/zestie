using UnityEngine;

public class L1Finish : MonoBehaviour
{
    public GameObject selamatObject; // Objek "Selamat" yang akan muncul

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pastikan Player punya tag "Player"
        {
            selamatObject.SetActive(true); // Aktifkan objek "Selamat"
        }
    }

}
