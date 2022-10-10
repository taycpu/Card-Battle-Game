using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private List<Transform> enemyPos;
    

    public void GenerateEnemy(int id)
    {
        enemies[id].Activate(enemyPos[id].position);
    }
}