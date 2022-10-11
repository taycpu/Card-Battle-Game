using System.Collections;
using System.Collections.Generic;
using GameAssets.Scripts.UI;
using GameAssets.Scripts.Units;
using GameAssets.Scripts.Units.Heroes;
using UnityEngine;

public class WinScreen : UIScreen
{
    [SerializeField] private List<PopupInfoUI> popUpCards;


    public void ShowCards(List<Unit> aliveHeroes)
    {
        for (int i = 0; i < aliveHeroes.Count; i++)
        {
            popUpCards[i].Initialize(aliveHeroes[i].characterAttribute);
            popUpCards[i].SetActive(true);
        }
    }
}