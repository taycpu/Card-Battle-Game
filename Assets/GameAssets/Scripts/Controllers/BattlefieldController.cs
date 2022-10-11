using System.Collections.Generic;
using GameAssets.Scripts.Factories;
using GameAssets.Scripts.SO_Containers;
using GameAssets.Scripts.Units;
using GameAssets.Scripts.Units.Heroes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameAssets.Scripts.Controllers
{
    public class BattlefieldController : MonoBehaviour
    {
        [SerializeField] private Factory heroFactory;
        [SerializeField] private Factory enemyFactory;
        [SerializeField] private RoundController roundController;
        [SerializeField] private BattlefieldUIController uiController;
        [SerializeField] private HeroInventory heroInventory;
        [SerializeField] private PlayerStat playerStat;
        [SerializeField] private WinScreen winScreen;

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
            playerStat.Win();
            uiController.Activate(0);

            for (int i = 0; i < aliveHeroes.Count; i++)
            {
                aliveHeroes[i].characterAttribute.TakeExperience(1);
            }


            winScreen.ShowCards(aliveHeroes);

            if (playerStat.WinCount % 5 == 0)
                heroInventory.UnlockRandomHero();
        }

        private void Lose()
        {
            playerStat.Lose();
            uiController.Activate(1);
            Debug.Log("Lose");
        }

        public void LoadMainScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}