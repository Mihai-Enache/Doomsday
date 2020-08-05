using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ArmourType
{
    Heavy,
    Medium,
    Light
}


[CreateAssetMenu(fileName = "New Armour", menuName = "Item/Equipable/Armour")]
public class ItemEquipableArmour : ItemEquipable
{
    public ArmourType type;
    public int minDef;
    public int maxDef;
    public float movSpeed;

    ItemEquipableArmour(ArmourType type, int minDef, int maxDef, float movSpeed, int price, ItemSlot slot, Rarity rarity, Attribute attributeToBoost, int bonus, int limit) : base(price, slot, rarity, attributeToBoost, bonus, limit)
    {
        this.type     = type;
        this.minDef   = setStatusByRarity(minDef);
        this.maxDef   = setStatusByRarity(maxDef);
        this.movSpeed = movSpeed;
    }

   
}
