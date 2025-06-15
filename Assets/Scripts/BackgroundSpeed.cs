using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float parallaxFactor = 0.5f; // 0 = diam, 1 = sama dengan kamera

    private Vector3 previousCameraPosition;

    private void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        previousCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - previousCameraPosition;
        transform.position += new Vector3(delta.x * parallaxFactor, 0, 0);
        previousCameraPosition = cameraTransform.position;
    }
}