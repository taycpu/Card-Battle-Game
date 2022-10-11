using System.Collections.Generic;
using GameAssets.Scripts.Misc;
using GameAssets.Scripts.SO_Containers;
using UnityEngine;

namespace GameAssets.Scripts.HeroCards
{
    public class HeroCardManager : Manager
    {
        [SerializeField] private List<HeroCard> heroCards;
        [SerializeField] private HeroInventory heroInventory;
        [SerializeField] private PlayerStat playerStat;


        public override void Initialize()
        {
            heroInventory.ClearPickedHeroes();
            LoadInventory();
            for (int i = 0; i < heroCards.Count; i++)
            {
                if (heroCards[i].IsUnlocked)
                {
                    heroCards[i].Initialize();
                    heroCards[i].gameObject.SetActive(true);
                }
            }
        }

        private void LoadInventory()
        {
            playerStat.Load();
            foreach (var heroAttribute in heroInventory.AllHeroes)
            {
                heroAttribute.Load();
            }
        }

        public override bool IsReady()
        {
            return heroInventory.PickedHeroes.Count >= 3;
        }
    }
}