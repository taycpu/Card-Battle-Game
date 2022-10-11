using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameAssets.Scripts.Factories
{
    public class EnemyFactory : Factory
    {
        [SerializeField] private List<Transform> enemyPos;


        private int placeCounter = 0;
        public override void Generate(int id, Action onAttackEnd)
        {
            base.Generate(id, onAttackEnd);
            units[id].Activate(enemyPos[placeCounter].position, onAttackEnd);
            placeCounter++;
        }
    }
}