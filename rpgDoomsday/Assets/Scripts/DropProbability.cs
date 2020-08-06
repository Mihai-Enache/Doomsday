using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DropProbability : MonoBehaviour
{
    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    public enum ItemType
    {
        Weapon,
        Armour,
        Special
    }

    //itemRarity[i] --> ce raritate are itemul dropat de mob
    //dropProbability[i] --> ce probabilitate de a fi dropat are itemul cu raritatea itemRarity[i]
    public ItemRarity[] itemRarity;
    public float[] dropProbability;

    private void Start()
    {
        //TODO DACA MOBUL MOARE ATUNCI Drop()
        Drop();
    }

    //45% sansa de a pica arma, 45% armura, 10% item special
    private ItemType ChooseItemType()
    {
        float probability = Random.Range(0f, 100f);
        if (probability < 45f)
            return ItemType.Weapon;
        if (probability > 90f)
            return ItemType.Special;
        else
            return ItemType.Armour;
    }

    //alege un item de un anumit tip (presupun ca fiecare prefab de item va avea un id)
    private int ChooseItemId(ItemType itemType)
    {
        if (itemType == ItemType.Weapon)
            return Random.Range(0, 16);
        else if (itemType == ItemType.Armour)
            return Random.Range(0, 11);
        else
            return Random.Range(0, 2);
    }

    private void Drop()
    {
        for (int i = 0; i < itemRarity.Length; i++)
        {
            //calculeaza sansa de drop
            float probability = Random.Range(0f, 100f);
            if (probability > 0 && probability <= dropProbability[i])
            {
                ItemType itemType = ChooseItemType();
                int itemId = ChooseItemId(itemType);

                //TODO GASESTE PREFABUL ITEMULUI DUPA ID

                //calculeaza bonusul de raritate
                int increaseRate = 0;
                if (itemRarity[i] == ItemRarity.Uncommon)
                    increaseRate = 20;
                else if (itemRarity[i] == ItemRarity.Rare)
                    increaseRate = 40;
                else if (itemRarity[i] == ItemRarity.Epic)
                    increaseRate = 60;
                else if (itemRarity[i] == ItemRarity.Legendary)
                    increaseRate = 80;

                if (itemType == ItemType.Weapon)
                {
                    //TODO EXTRAGE MIN_DAMAGE SI MAX_DAMAGE
                    //int damage = Random.Range(MIN_DAMAGE, MAX_DAMAGE);
                    //damage += (increaseRate / 100) * damage;

                    //TODO EXTRAGE MIN_ATTRIBUTE
                    //int attributeValue = Random.Range(MIN_ATTRIBUTE, MIN_ATTRIBUTE + 10);
                }
                else if(itemType == ItemType.Armour)
                {
                    //TODO EXTRAGE MIN_DEFENCE SI MAX_DEFENCE
                    //int defence = Random.Range(MIN_DEFENCE, MAX_DEFENCE);
                    //defence += (increaseRate / 100) * defence;

                    //TODO EXTRAGE MIN_ATTRIBUTE
                    //int attributeValue = Random.Range(MIN_ATTRIBUTE, MIN_ATTRIBUTE + 10);
                }
                else if(itemType == ItemType.Special)
                {
                    //TODO EXTRAGE EFFECT_VALUE
                    //EFFECT_VALUE += (increaseRate / 100) * EFFECT_VALUE;
                }
            }
            else
            {
                //nu dropeaza nimic
            }
        }
    }
}
