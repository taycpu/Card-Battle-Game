using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Factory
{
    [SerializeField] private List<Transform> enemyPos;


    public override void Generate(int id, Action onAttackEnd)
    {
        base.Generate(id, onAttackEnd);
        units[id].Activate(enemyPos[id].position, onAttackEnd);
    }
}