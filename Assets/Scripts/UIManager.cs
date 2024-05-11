using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject shopUI;
    private bool isInventoryOpen = false;

    // Singleton instance
    public static UIManager instance;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of UIManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of UIManager found!");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Open/close inventory with "I" button
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        // Check for interaction with shopkeeper
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for interaction
        {
            InteractWithShopkeeper();
        }
    }

    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    void InteractWithShopkeeper()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Shopkeeper"))
            {
                // Open shop UI and display inventory
                shopUI.SetActive(true);
                inventoryUI.SetActive(true);
            }
        }
    }
}
