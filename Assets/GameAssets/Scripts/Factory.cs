using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    [SerializeField] protected List<Unit> units;

    [SerializeField] private UnitController unitController;

    public virtual void Generate(int id, Action onAttackEnd)
    {
        unitController.SetActiveUnits(units[id]);
    }
}