using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    Melee,
    Ranged
}


[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Equipable/Weapon")]
public class ItemEquipableWeapon : ItemEquipable
{
    public WeaponType type;
    public int minAtk;
    public int maxAtk;
    public int range;
    public float atkSpeed;
    public Buff effect;

    ItemEquipableWeapon(WeaponType type, int minAtk, int maxAtk, int range, float atkSpeed, Buff effect, int price, ItemSlot slot, Rarity rarity, Attribute attributeToBoost, int bonus, int limit) : base(price, slot, rarity, attributeToBoost, bonus, limit)
    {
        this.type     = type;
        this.minAtk   = setStatusByRarity(minAtk);
        this.maxAtk   = setStatusByRarity(maxAtk);
        this.range    = range;
        this.atkSpeed = atkSpeed;
        this.effect = effect;
    }

    
}
