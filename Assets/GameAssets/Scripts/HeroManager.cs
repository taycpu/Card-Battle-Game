using System.Collections.Generic;
using UnityEngine;

public class HeroManager : Manager
{
    [SerializeField] private List<HeroCard> heroCards;
    
    public override void Initialize()
    {
        for (int i = 0; i < heroCards.Count; i++)
        {
            if(heroCards[i].IsUnlocked)
                heroCards[i].gameObject.SetActive(true);
        }
        print("Hero cards inits");
    }
}