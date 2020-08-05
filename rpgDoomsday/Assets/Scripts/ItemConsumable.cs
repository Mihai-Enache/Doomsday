using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType
{
    Potion,
    Coin
}

[CreateAssetMenu(fileName = "New Consumable", menuName = "Item/Consumable")]
public class ItemConsumable : Item
{
    public ConsumableType type;
    public Buff effect;

    ItemConsumable(int stackSizeMax)
    {
        this.stackSizeMax = stackSizeMax;
    }

    public override void Use()
    {
        --stackSize;
        if (stackSize <= 0)
            owner.RemoveItem(backpackIndex);
        Hero hero = ((PlayerInventory)owner).hero;

        if (this.type != ConsumableType.Coin)
            hero.ApplyBuff(effect, hero);
    }
}