using System.Collections.Generic;
using UnityEngine;

public class HeroManager : Manager
{
    [SerializeField] private List<HeroCard> heroCards;
    [SerializeField] private HeroInventory heroInventory;

    public override void Initialize()
    {
        heroInventory.ClearPickedHeroes();
        for (int i = 0; i < heroCards.Count; i++)
        {
            if (heroCards[i].IsUnlocked)
            {
                heroCards[i].Initialize();

                heroCards[i].gameObject.SetActive(true);
            }
        }

        print("Hero cards inits");
    }
}