using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public GameObject popUp; // Reference to the Pop-up GameObject
    public bool canInteract = false; // Flag to determine if interaction is allowed

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Display pop-up when the player enters the trigger collider
            popUp.SetActive(true);
            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide pop-up when the player exits the trigger collider
            popUp.SetActive(false);
            canInteract = false;

        }
    }

    void Update()
    {
        // Check for player input to interact
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            // Hide pop-up when player interacts
            popUp.SetActive(false);

            // Call method to handle interaction
            UIManager.Instance.OpenShop();
        }
    }
}
