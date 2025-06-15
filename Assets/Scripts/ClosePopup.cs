using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public GameObject popupImage;
    public GameObject blurBackground;
    public GameObject player;

    public void Close()
    {
        Debug.Log("Close button clicked!");  // Tambahan debug

        if (popupImage != null)
            popupImage.SetActive(false);

        if (blurBackground != null)
            blurBackground.SetActive(false);

        if (player != null)
        {
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            if (movement != null)
                movement.enabled = true;
        }
    }

}
