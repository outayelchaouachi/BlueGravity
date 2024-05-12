using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Singleton instance
    public static PlayerController Instance;

    //References to Player sprites
    [SerializeField] private SpriteRenderer headSpriteRenderer;
    [SerializeField] private SpriteRenderer torsoSpriteRenderer;
    [SerializeField] private SpriteRenderer legsSpriteRenderer;
    private Item equippedHead;
    private Item equippedTorso;
    private Item equippedlegs;
    //Player Balance/Money
    private int playerCurrency = 1500;

    private void Awake()
    {
        Instance = this;
        UIManager.Instance.UpdatePlayerBlance(playerCurrency);
    }

    public void BuyItem(Item item)
    {
        if (CheckCurrency(item.price) && !InventoryManager.Instance.CheckItemInInventory(item))
        {
            // Deduct the item's price from the player's currency
            DeductCurrency(item.price);

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
        if (InventoryManager.Instance.CheckItemInInventory(item) && !IsItemEquipped(item))
        {
            // Add half of the item price to the player's currency
            AddCurrency(item.price / 2);

            // Remove the item from the player's inventory
            InventoryManager.Instance.RemoveItem(item);
            ToolTip.Instance.ShowToolTip_Static("Item sold !");
            Debug.Log("Sold " + item.itemName);
        }
        else
        {
            if (IsItemEquipped(item))
            {
                ToolTip.Instance.ShowToolTip_Static("Unable to sell equipped item !");
                return;
            }
            ToolTip.Instance.ShowToolTip_Static("Item not in inventory !");
            Debug.Log("Unable to sell item: " + item.itemName + ". Not in inventory or equipped.");
        }
    }
    //Equipe item depding on slot
    public void EquipItem(Item item)
    {
        switch (item.equipSlot)
        {
            case EquipmentSlot.Head:
                equippedHead = item;
                headSpriteRenderer.sprite = item.icon;
                ToolTip.Instance.ShowToolTip_Static("Item Equipped !");
                AudioManager.Instance.PlaySFX("EquipItem");
                break;
            case EquipmentSlot.Torso:
                equippedTorso = item;
                torsoSpriteRenderer.sprite = item.icon;
                ToolTip.Instance.ShowToolTip_Static("Item Equipped !");
                AudioManager.Instance.PlaySFX("EquipItem");

                break;
            case EquipmentSlot.Legs:
                equippedlegs = item;
                legsSpriteRenderer.sprite = item.icon;
                ToolTip.Instance.ShowToolTip_Static("Item Equipped !");
                AudioManager.Instance.PlaySFX("EquipItem");
                break;
            default:
                Debug.LogWarning("Cannot equip item to this slot.");
                break;
        }
    }

    //Check if item is equipped
    public bool IsItemEquipped(Item item)
    {
        if (equippedHead == item || equippedTorso == item)
        {
            Debug.Log("Item is Equipped");
            return true;
        }

        return false;
    }

    //Check if player can affoard item
    public  bool CheckCurrency(int price)
    {
        return playerCurrency > price;
    }

    //update player balance after buying item
    public void DeductCurrency(int price)
    {
        playerCurrency -= price;
        UIManager.Instance.UpdatePlayerBlance(playerCurrency);
    }

    ///update player balance after selling item
    public void AddCurrency(int price)
    {
        playerCurrency += price;
        UIManager.Instance.UpdatePlayerBlance(playerCurrency);
        AudioManager.Instance.PlaySFX("BuyItem");
    }
}
