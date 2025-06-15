using System.IO;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + 5, transform.position.y, transform.position.z);
    }
    void Start()
    {
        
    }
    
}
