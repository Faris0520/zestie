using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPoint;
    private Health playerHealth;

    private void Start()
    {
        // Jika spawnPoint belum di-set di Inspector, gunakan posisi awal saat Start
        if (spawnPoint == Vector3.zero)
            spawnPoint = transform.position;

        // Ambil komponen Health pada player
        playerHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ganti "RespawnTrigger" dengan tag yang sesuai pada objek trigger respawn
        if (collision.CompareTag("RespawnTrigger"))
        {
            transform.position = spawnPoint;
            Debug.Log("Player respawned to starting position.");

            // Kurangi health sebanyak 25
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(25f);
            }
        }
    }
}