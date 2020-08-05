using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Armour", menuName = "Item/SpecialWeapon")]
public class ItemEquipableSpecialWeapon : ItemEquipable
{
    public WeaponType type;
    public Buff effect;
    public int effectStacks;
    

    ItemEquipableSpecialWeapon(WeaponType type, Buff effect ,int price, ItemSlot slot, Rarity rarity, Attribute attributeToBoost, int bonus, int limit) : base(price, slot, rarity, attributeToBoost, bonus, limit)
    {
        this.type = type;
        this.effect = effect;
        switch (this.rarity)
        {
            case Rarity.Common:
                {
                    this.effectStacks = 5;
                    break;
                }
            case Rarity.Uncommon:
                {
                    this.effectStacks = 6;
                    break;
                }
            case Rarity.Rare:
                {
                    this.effectStacks = 7;
                    break;
                }
            case Rarity.Epic:
                {
                    this.effectStacks = 8;
                    break;
                }
            case Rarity.Legendary:
                {
                    this.effectStacks = 9;
                    break;
                }
        }
        
    }


}
