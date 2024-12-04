using UnityEngine;
using UnityEngine.UI;

public class CrosshairRaycast : MonoBehaviour
{
    public Camera playerCamera;      // Assign the player's camera
    public Image crosshairImage;     // The UI image for the crosshair
    public Color defaultColor = Color.white;   // Default crosshair color
    public Color interactColor = Color.green;  // Crosshair color when looking at interactable
    public float raycastRange = 100f;          // Range of the raycast

    void Start()
    {
        // Ensure the camera and crosshair are assigned
        if (playerCamera == null)
        {
            playerCamera = Camera.main; // Automatically find the main camera
        }

        if (crosshairImage == null)
        {
            Debug.LogError("Crosshair Image not assigned!");
        }
    }

    void Update()
    {
        UpdateCrosshair();
    }

    void UpdateCrosshair()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * raycastRange, Color.red); // Debug visualization

        if (Physics.Raycast(ray, out RaycastHit hit, raycastRange))
        {
            Debug.Log($"Looking at: {hit.collider.gameObject.name}");

            // Change crosshair color if looking at an "Interactable" object
            if (hit.collider.CompareTag("Interactable"))
            {
                crosshairImage.color = interactColor;
            }
            else
            {
                crosshairImage.color = defaultColor;
            }
        }
        else
        {
            // Revert to default color if not looking at anything specific
            crosshairImage.color = defaultColor;
        }
    }
}
