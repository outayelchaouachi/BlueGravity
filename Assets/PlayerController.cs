using UnityEngine;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;

    public int playerCurrency=5000;

    public SpriteRenderer headSpriteRenderer;
    public SpriteRenderer torsoSpriteRenderer;
    public SpriteRenderer legsSpriteRenderer;
    // Add more SpriteRenderers for other body parts as needed

    private Item equippedHead;
    private Item equippedTorso;
    private Item equippedlegs;
    // Add more equipped items variables for other body parts as needed

    private void Awake()
    {
        Instance = this;

    }

    public void EquipItem(Item item)
    {
        switch (item.equipSlot)
        {
            case EquipmentSlot.Head:
                equippedHead = item;
                headSpriteRenderer.sprite = item.icon;
                ToolTip.Instance.ShowToolTip_Static("Item Equipped !");
                break;
            case EquipmentSlot.Torso:
                equippedTorso = item;
                torsoSpriteRenderer.sprite = item.icon;
                ToolTip.Instance.ShowToolTip_Static("Item Equipped !");
                break;
            case EquipmentSlot.Legs:
                equippedlegs = item;
                legsSpriteRenderer.sprite = item.icon;
                ToolTip.Instance.ShowToolTip_Static("Item Equipped !");
                break;
            // Handle other equipment slots here
            default:
                Debug.LogWarning("Cannot equip item to this slot.");
                break;
        }
    }
    public bool IsItemEquipped(Item item)
    {
        if (equippedHead == item || equippedTorso == item)
        {
            Debug.Log("Item is Equipped");
            return true;
        }

        return false;
    }
    public  bool CheckCurrency(int price)
    {
        return playerCurrency > price;
    }

    public void DeductCurrency(int price)
    {
        playerCurrency -= price;
    }

    public void AddCurrency(int price)
    {
        playerCurrency += price;
    }


    // Implement methods for unequipping items, if needed
}
