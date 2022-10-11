using System;
using System.Collections;
using System.Collections.Generic;
using GameAssets.Scripts.UI;
using UnityEngine;
using Unit = GameAssets.Scripts.Units.Unit;

namespace GameAssets.Scripts.Controllers
{
    public class RoundController : MonoBehaviour
    {
        public Action<List<Unit>> WinEvent;
        public Action LoseEvent;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private TimerUI timerUI;


        private bool isPlayerTurn = false;

        private const float WaitTime = 1.5f;

        public void SwitchTurn()
        {
            isPlayerTurn = !isPlayerTurn;
            StartCoroutine(WaitForNextRound());
        }

        IEnumerator WaitForNextRound()
        {
            float totalTime = 0;
            timerUI.Activate(true);

            while (totalTime <= WaitTime)
            {
                timerUI.FillCircle(totalTime / WaitTime);
                totalTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            timerUI.Activate(false);

            if (enemyController.IsAllUnitsDead())
            {
                WinEvent(playerController.GetLiveUnits());
            }
            else if (playerController.IsAllUnitsDead())
            {
                LoseEvent?.Invoke();
            }
            else if (isPlayerTurn)
            {
                playerController.GetReadyForTurn(enemyController.GetActiveUnit());
            }
            else if (!isPlayerTurn)
            {
                enemyController.GetReadyForTurn(playerController.GetActiveUnit());
            }
        }
    }
}