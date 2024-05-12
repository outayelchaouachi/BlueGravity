using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    // Singleton instance
    public static InventoryManager Instance;

    [SerializeField] private ItemUI itemPrefab; // The prefab for the item
    [SerializeField] private Transform itemListParent; // Parent object for the item UI elements
    [SerializeField] private List<Item> items = new List<Item>();

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
            ItemUI invItem = Instantiate(itemPrefab, itemListParent);
            // Setup the item UI prefab
            invItem.Setup(item, false);
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
