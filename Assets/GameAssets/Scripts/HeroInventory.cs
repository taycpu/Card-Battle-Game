using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventory : MonoBehaviour
{
    public static HeroInventory Instance;

    public List<CharacterAttribute> PickedHeroes => pickedHeroes;
    [SerializeField] private List<CharacterAttribute> pickedHeroes;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
        DontDestroyOnLoad(Instance);
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