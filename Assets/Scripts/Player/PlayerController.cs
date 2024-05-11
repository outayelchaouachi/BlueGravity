using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{
    // Singleton instance
    public static PlayerController Instance;

    public int playerCurrency=500;

    public SpriteRenderer headSpriteRenderer;
    public SpriteRenderer torsoSpriteRenderer;
    public SpriteRenderer legsSpriteRenderer;
    private Item equippedHead;
    private Item equippedTorso;
    private Item equippedlegs;

    public TextMeshProUGUI balanceText;


    private void Awake()
    {
        Instance = this;
        balanceText.text =playerCurrency.ToString();  
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
        balanceText.text=playerCurrency.ToString();
    }

    public void AddCurrency(int price)
    {
        playerCurrency += price;
        balanceText.text = playerCurrency.ToString();
    }


    // Implement methods for unequipping items, if needed
}
