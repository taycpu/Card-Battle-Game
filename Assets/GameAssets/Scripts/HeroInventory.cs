using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create HeroInventory", fileName = "HeroInventory", order = 0)]
public class HeroInventory : ScriptableObject
{
    public List<CharacterAttribute> AllHeroes;

    public List<CharacterAttribute> PickedHeroes => pickedHeroes;
    [SerializeField] private List<CharacterAttribute> pickedHeroes;


    public void UnlockRandomHero()
    {
        var unlocked = AllHeroes.FindAll(s => !s.IsUnlocked);
        if (unlocked.Count == 0) return;

        unlocked.GetRandom().IsUnlocked = true;
    }

    public void PickHero(CharacterAttribute characterAttribute)
    {
        pickedHeroes.Add(characterAttribute);
    }

    public void UnPickHero(CharacterAttribute characterAttribute)
    {
        pickedHeroes.Remove(characterAttribute);
    }

    public void ClearPickedHeroes()
    {
        pickedHeroes.Clear();
    }
}