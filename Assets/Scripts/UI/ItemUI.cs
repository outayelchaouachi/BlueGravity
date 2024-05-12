using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button EquipButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;

    public void Setup(Item item,bool isShop)
    {
        itemName.text = item.name;
        itemImage.sprite = item.icon;
        if (isShop)
        {
            itemPrice.text = item.price.ToString();
            buyButton.onClick.AddListener(() => PlayerController.Instance.BuyItem(item));
            sellButton.onClick.AddListener(() => PlayerController.Instance.SellItem(item));
        }
        else
        {
            EquipButton.onClick.AddListener(() => PlayerController.Instance.EquipItem(item));
        }
    }
}
