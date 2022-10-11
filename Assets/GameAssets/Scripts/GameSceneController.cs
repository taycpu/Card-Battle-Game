using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private Factory heroFactory;
    [SerializeField] private Factory enemyFactory;
    [SerializeField] private RoundController roundController;
    [SerializeField] private BattlefieldUIController uiController;
    [SerializeField] private HeroInventory heroInventory;


    private void Awake()
    {
        SpawnHeroes();
        SpawnEnemies();
        roundController.WinEvent = Win;
        roundController.LoseEvent = Lose;
        roundController.SwitchTurn();
    }

    private void SpawnEnemies()
    {
        enemyFactory.Generate(0, roundController.SwitchTurn);
    }

    private void SpawnHeroes()
    {
        var heroes = heroInventory.PickedHeroes;
        for (int i = 0; i < heroes.Count; i++)
        {
            heroFactory.Generate(heroes[i].HeroId, roundController.SwitchTurn);
        }
    }

    private void Win(List<Unit> aliveHeroes)
    {
        uiController.Activate(0);
        heroInventory.UnlockRandomHero();
        for (int i = 0; i < aliveHeroes.Count; i++)
        {
            aliveHeroes[i].characterAttribute.TakeExperience(1);
        }

        Debug.Log("Winned");
    }

    private void Lose()
    {
        uiController.Activate(1);
        Debug.Log("Lose");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
}