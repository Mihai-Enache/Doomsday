using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public class ItemEquipable : Item
{
    // slot pentru fiecare tip de item
    public ItemSlot slot;
    public Rarity rarity;
    public Attribute attributeToBoost;
    public int bonus;
    public int limit;


    // modificat constructor 
    protected ItemEquipable(int price, ItemSlot slot, Rarity rarity, Attribute attributeToBoost, int bonus, int limit)
    {
        this.price              = price;
        this.slot               = slot;
        this.rarity             = rarity;
        this.attributeToBoost   = attributeToBoost;
        this.bonus              = bonus;
        this.limit              = limit;
        stackSizeMax            = 1;
    }

    public override void Use()
    {
        ((PlayerInventory)owner).EquipItem(backpackIndex);
    }

   protected int setStatusByRarity(int stat)
    {


        switch (this.rarity)
        {
            case Rarity.Common:
                {

                    break;
                }
            case Rarity.Uncommon:
                {
                    stat += (int)(0.2 * stat);
                    break;
                }
            case Rarity.Rare:
                {
                    stat += (int)(0.4 * stat);
                    break;
                }
            case Rarity.Epic:
                {
                    stat += (int)(0.6 * stat);
                    break;
                }
            case Rarity.Legendary:
                {
                    stat += (int)(0.8 * stat);
                    break;
                }
        }

        return stat;
    }

}

