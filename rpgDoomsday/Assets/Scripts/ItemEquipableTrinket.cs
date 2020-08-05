using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trinket", menuName = "Item/Equipable/Trinket")]
public class ItemEquipableTrinket : ItemEquipable
{
    // Start is called before the first frame update
    ItemEquipableTrinket(int price, ItemSlot slot, Rarity rarity, Attribute attributeToBoost, int bonus) : base(price, slot, rarity, attributeToBoost, bonus, 0)
    {
       
    }
}
