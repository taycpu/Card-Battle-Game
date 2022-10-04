using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Hero", fileName = "Hero", order = 0)]

public class HeroAttribute : ScriptableObject
{
    public string heroName;
    public Color color;
    public int heroId;
    public int health;
    public int attackPower;
    public int experience;
    [Range(1, 99)] public int level;
    public bool IsUnlocked;
}