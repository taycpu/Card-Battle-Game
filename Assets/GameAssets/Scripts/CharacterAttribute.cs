using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Hero", fileName = "Character", order = 0)]
public class CharacterAttribute : ScriptableObject
{
    #region Attributes

    public bool IsUnlocked;
    public string HeroName => heroName;
    public Color Color => color;
    public int HeroId => heroId;
    public double Health => health;
    public double AttackPower => attackPower;
    public int Experience => experience;
    public int Level => level;

    #endregion


    [SerializeField] private string heroName;
    [SerializeField] private Color color;
    [SerializeField] private int heroId;
    [SerializeField] private double health;
    [SerializeField] private double attackPower;
    [SerializeField] private int experience;
    [SerializeField] private int level;

    public void TakeExperience(int amount)
    {
        experience += amount;
        if (experience >= 5)
        {
            experience = 0;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        health += health / 10;
        attackPower += attackPower / 10f;
    }
}