using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventory : MonoBehaviour
{
    public static HeroInventory Instance;
    
    [SerializeField]private List<Hero> pickedHeroes = new List<Hero>();
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
        DontDestroyOnLoad(Instance);
    }
    public void PickHero(Hero hero)
    {
        pickedHeroes.Add(hero);
    }

    public void UnPickHero(Hero hero)
    {
        pickedHeroes.Remove(hero);
    }
}