using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyController enemyController;

    public Action<List<Unit>> WinEvent;
    public Action LoseEvent;


    private bool isPlayerTurn = false;

    private const int WaitTime = 1;

    public void SwitchTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        StartCoroutine(WaitForNextRound());
    }

    IEnumerator WaitForNextRound()
    {
        int startTime = 0;
        while (startTime <= WaitTime)
        {
            startTime++;
            yield return new WaitForSeconds(1);
        }

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