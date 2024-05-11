using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot
{
    None,
    Head,
    Torso,
    Legs,
    Hands,
    // Add more equipment slots as needed
}

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite icon;
    public int price;
    public EquipmentSlot equipSlot;

}
