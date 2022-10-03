using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : ScriptableObject
{
    public string heroName;
    public int health;
    public int attackPower;
    public int experience;
    public int level;
    public bool IsUnlocked;
}