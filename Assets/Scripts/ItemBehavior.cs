using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public Item item; // Reference to the scriptable object representing this item

    // Method to handle purchasing the item from the shopkeeper
    public void BuyItem()
    {
        // Add the purchased item to the player's inventory
        InventoryManager.Instance.AddItem(item);

        // Optionally, remove the item from the shopkeeper's inventory
        // ShopkeeperInventory.instance.RemoveItemFromInventory(item);

        Debug.Log("Purchased " + item.itemName);
    }

    // Method to handle using/consuming the item from the player's inventory
    public void UseItem()
    {
        // Implement your item usage logic here
        PlayerController.Instance.EquipItem(item);
        Debug.Log("Used " + item.itemName);
    }
}
