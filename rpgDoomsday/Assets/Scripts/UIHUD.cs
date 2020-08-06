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
    public TMP_Text strText;
    public TMP_Text dexText;
    public TMP_Text wisText;
    public TMP_Text pointsText;

    public Slider hslider;
    public Slider mslider;
    public Slider xpslider;

    private void Update()
    {
        healthText.text = Mathf.FloorToInt(hero.health) + "/" + Mathf.FloorToInt(hero.healthMax);
        hslider.value = Mathf.FloorToInt(hero.health);
        hslider.maxValue = Mathf.FloorToInt(hero.healthMax);
        manaText.text = Mathf.FloorToInt(hero.mana) + "/" + Mathf.FloorToInt(hero.manaMax);
        mslider.value = Mathf.FloorToInt(hero.mana);
        mslider.maxValue = Mathf.FloorToInt(hero.manaMax);
        xpText.text = hero.xp + "/" + hero.ExperienceForLevel(hero.level);
        xpslider.value = hero.xp;
        xpslider.maxValue = hero.ExperienceForLevel(hero.level);
        lvlText.text = "Level " + hero.level + " " + GetHeroClassName(hero.heroClass);
        goldText.text = hero.inventory.gold + " Gold";
        strText.text = "STR: " + hero.strength;
        dexText.text = "DEX: " + hero.dexterity;
        wisText.text = "WIS: " + hero.wisdom;
        if (hero.points > 0)
            pointsText.text = hero.points + " unspent points";
        else
            pointsText.text = "";
    }

    public static string GetHeroClassName(HeroClass hc)
    {
        string s = hc.ToString().ToLower();
        return char.ToUpper(s[0]) + s.Substring(1);
    }
}
