using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventory : MonoBehaviour
{
    public static HeroInventory Instance;

    public List<HeroAttribute> PickedHeroes => pickedHeroes;
    [SerializeField] private List<HeroAttribute> pickedHeroes;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void PickHero(HeroAttribute heroAttribute)
    {
        pickedHeroes.Add(heroAttribute);
    }

    public void UnPickHero(HeroAttribute heroAttribute)
    {
        pickedHeroes.Remove(heroAttribute);
    }

    public void ClearPickedHeroes()
    {
        pickedHeroes.Clear();
    }
}