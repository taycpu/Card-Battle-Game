using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyController enemyController;

    public Action WinEvent;
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

        if (isPlayerTurn)
        {
            if (!enemyController.IsAllUnitsDead())
            {
                playerController.GetReadyForTurn(enemyController.GetActiveUnit());
            }
            else
            {
                WinEvent?.Invoke();
            }
        }

        else
        {
            if (!playerController.IsAllUnitsDead())
            {
                enemyController.GetReadyForTurn(playerController.GetActiveUnit());
            }
            else
            {
                LoseEvent?.Invoke();
            }
        }
    }
}