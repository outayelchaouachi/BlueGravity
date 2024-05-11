using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    // Singleton instance
    public static InventoryManager Instance;

    public GameObject itemPrefab; // The prefab for the item
    public Transform itemListParent; // Parent object for the item UI elements
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ListItems();
    }

    public void ListItems()
    {
        foreach (Transform item in itemListParent.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Item item in items)
        {
            // Instantiate the item UI prefab
            GameObject newItemUI = Instantiate(itemPrefab, itemListParent);

            // Get references to UI elements in the item UI prefab
            TextMeshProUGUI itemNameText = newItemUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            Image itemImage = newItemUI.transform.Find("ItemImage").GetComponent<Image>();

            // Assign item data to UI elements
            itemNameText.text = item.itemName;
            itemImage.sprite = item.icon;
            // Assign EquipItem method to the Item button
            Button EquipButton = newItemUI.transform.GetComponent<Button>();
            EquipButton.onClick.AddListener(() => PlayerController.Instance.EquipItem(item));
        }
    }

    //Method to add item to the item list
    public void AddItem(Item item)
    {
        items.Add(item);
        ListItems();

    }

    //Method to remove item from the item list
    public void RemoveItem(Item item) 
    {
        items.Remove(item);
        ListItems();

    }

    //Method to check if the item is in the item list
    public bool CheckItemInInventory(Item item)
    {
        return items.Contains(item);
    }
}
