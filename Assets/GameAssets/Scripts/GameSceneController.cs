using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private Factory heroFactory;
    [SerializeField] private Factory enemyFactory;


    private void Awake()
    {
        SpawnHeroes();
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        enemyFactory.Generate(0);
    }

    private void SpawnHeroes()
    {
        var heroes = HeroInventory.Instance.PickedHeroes;
        for (int i = 0; i < heroes.Count; i++)
        {
            heroFactory.Generate(heroes[i].heroId);
        }
    }
    
}

public class RoundController:MonoBehaviour
{
    public void SwitchTurn()
    {
        
    }
}