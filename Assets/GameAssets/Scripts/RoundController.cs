using UnityEngine;

public class RoundController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyController enemyController;

    private bool isPlayerTurn = false;

    public void SwitchTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {
            playerController.GetReadyForTurn(enemyController.GetActiveUnit());
        }

        else
        {
            enemyController.GetReadyForTurn(playerController.GetActiveUnit());
        }
    }
}