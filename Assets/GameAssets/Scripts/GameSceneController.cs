using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private Factory heroFactory;
    [SerializeField] private Factory enemyFactory;
    [SerializeField] private RoundController roundController;


    private void Awake()
    {
        SpawnHeroes();
        SpawnEnemies();
        roundController.SwitchTurn();
    }

    private void SpawnEnemies()
    {
        enemyFactory.Generate(0, roundController.SwitchTurn);
    }

    private void SpawnHeroes()
    {
        var heroes = HeroInventory.Instance.PickedHeroes;
        for (int i = 0; i < heroes.Count; i++)
        {
            heroFactory.Generate(heroes[i].heroId, roundController.SwitchTurn);
        }
    }
}