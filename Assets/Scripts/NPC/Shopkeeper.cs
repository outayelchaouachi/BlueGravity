using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private ItemUI shopItemPrefab;
    [SerializeField] private Transform itemListParent; // Parent object for the item UI elements
    [SerializeField] private List<Item> shopInventory; // List of items in the shop
    [SerializeField] private GameObject popUp; // Reference to the Pop-up GameObject


    private void Start()
    {
        ListShopItems();
    }

    // Method to List the shop with items to sell
    public void ListShopItems()
    {
        foreach (Item item in shopInventory)
        {
            // Instantiate the item UI prefab
            ItemUI shopItem = Instantiate(shopItemPrefab, itemListParent);
            // Setup the item UI prefab
            shopItem.Setup(item, true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Display pop-up when the player enters the trigger collider
            popUp.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIManager.Instance.OpenShop();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide pop-up when the player exits the trigger collider
            popUp.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKeyUp(KeyCode.E)) 
        {
            UIManager.Instance.OpenShop();
        }
    }
}
