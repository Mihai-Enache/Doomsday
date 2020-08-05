using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHUD : MonoBehaviour
{
    public Hero hero;
    public TMP_Text healthText;
    public TMP_Text manaText;
    public TMP_Text xpText;
    public TMP_Text lvlText;
    public TMP_Text goldText;

    public Slider hslider;
    public Slider mslider;

    private void Update()
    {
        healthText.text = Mathf.FloorToInt(hero.health) + "/" + Mathf.FloorToInt(hero.healthMax);
        hslider.value = hero.health;
        manaText.text = Mathf.FloorToInt(hero.mana) + "/" + Mathf.FloorToInt(hero.manaMax);
        mslider.value = hero.mana;
        xpText.text = hero.xp + "/" + hero.ExperienceForLevel(hero.level);
        lvlText.text = "Level " + hero.level;
        goldText.text = hero.inventory.gold + " Gold";
    }
}
