using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    public GameObject itemToSellPrefab; // The prefab for the item
    public Transform itemListParent; // Parent object for the item UI elements
    public List<Item> shopInventory; // List of items in the shop

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
            GameObject newItemUI = Instantiate(itemToSellPrefab, itemListParent);

            // Get references to UI elements in the item UI prefab
            TextMeshProUGUI itemNameText = newItemUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI itemPriceText = newItemUI.transform.Find("ItemPrice").GetComponent<TextMeshProUGUI>();
            Image itemImage = newItemUI.transform.Find("ItemImage").GetComponent<Image>();

            // Assign item data to UI elements
            itemNameText.text = item.itemName;
            itemPriceText.text = item.price.ToString();
            itemImage.sprite = item.icon;

            // Assign buy method to the Buy button
            Button buyButton = newItemUI.transform.Find("BuyButton").GetComponent<Button>();
            buyButton.onClick.AddListener(() => BuyItem(item));

            // Assign sell method to the Sell button
            Button sellButton = newItemUI.transform.Find("SellButton").GetComponent<Button>();
            sellButton.onClick.AddListener(() => SellItem(item));
        }
    }

    public void BuyItem(Item item)
    {
        Debug.Log("Item Price= " + item.price + " Currency = " + PlayerController.Instance.playerCurrency);
        if (PlayerController.Instance.CheckCurrency(item.price) && !InventoryManager.Instance.CheckItemInInventory(item))
        {
            // Deduct the item's price from the player's currency
            PlayerController.Instance.DeductCurrency(item.price);

            // Add the item to the player's inventory
            InventoryManager.Instance.AddItem(item);
            ToolTip.Instance.ShowToolTip_Static("Item bought !");
            Debug.Log("Purchased " + item.itemName);
        }
        else
        {
            ToolTip.Instance.ShowToolTip_Static("Unable to buy item !");
            Debug.Log("Unable to buy item: " + item.itemName + ". Not enough currency.");
        }

    }

    // Sell an item to the shopkeeper
    public void SellItem(Item item)
    {
        //Check if item is in inventory and check if it is equipped
        if (InventoryManager.Instance.CheckItemInInventory(item)&& !PlayerController.Instance.IsItemEquipped(item))
        {
            // Add half of the item price to the player's currency
            PlayerController.Instance.AddCurrency(item.price/2);

            // Remove the item from the player's inventory
            InventoryManager.Instance.RemoveItem(item);
            ToolTip.Instance.ShowToolTip_Static("Item sold !");
            Debug.Log("Sold " + item.itemName);
        }
        else
        {

            if (PlayerController.Instance.IsItemEquipped(item))
            {
                ToolTip.Instance.ShowToolTip_Static("Unable to sell equipped item !");
                return;
            }
            ToolTip.Instance.ShowToolTip_Static("Item not in inventory !");
            Debug.Log("Unable to sell item: " + item.itemName + ". Not in inventory or equipped.");
        }
    }
}
