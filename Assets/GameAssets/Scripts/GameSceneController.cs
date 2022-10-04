using System;
using System.Collections;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private HeroFactory heroFactory;

    private void Awake()
    {
        var heroes = HeroInventory.Instance.PickedHeroes;


        for (int i = 0; i < heroes.Count; i++)
        {
            heroFactory.GenerateHero(heroes[i].heroId);
        }
    }
}
