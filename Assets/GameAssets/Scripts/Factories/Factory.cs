using System;
using System.Collections.Generic;
using GameAssets.Scripts.Controllers;
using GameAssets.Scripts.Units;
using UnityEngine;

namespace GameAssets.Scripts.Factories
{
    public abstract class Factory : MonoBehaviour
    {
        [SerializeField] protected List<Unit> units;
        [SerializeField] private UnitController unitController;

        public virtual void Generate(int id, Action onAttackEnd)
        {
            unitController.SetActiveUnits(units[id]);
        }
    }
}