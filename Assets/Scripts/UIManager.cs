using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager Instance;

    public GameObject inventoryUI;
    public GameObject shopUI;
    private bool isInventoryOpen = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Open/close inventory with "I" button
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        // Check for interaction with shopkeeper left mouse clic
        if (Input.GetMouseButtonDown(0))
        {
            //InteractWithShopkeeper();
        }
    }

    // Toggle Inventory
    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);
    }


    // Close Shop & Inventory
    public void CloseShop()
    {
        shopUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    public void OpenShop() 
    {
        // Open shop UI and display inventory
        shopUI.SetActive(true);
        inventoryUI.SetActive(true);
    }

    //Interaction with the shopkeeper
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
