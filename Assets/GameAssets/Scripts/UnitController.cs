using System.Collections.Generic;
using UnityEngine;

public abstract class UnitController : MonoBehaviour
{
    [SerializeField] protected List<Unit> activeUnits;

    public void SetActiveUnits(Unit unit)
    {
        activeUnits.Add(unit);
    }

    public void GetReadyForTurn(Unit rivalUnit)
    {
        for (int i = 0; i < activeUnits.Count; i++)
        {
            activeUnits[i].AssignRival(rivalUnit);
        }

        SetUnit(activeUnits, rivalUnit);
    }


    protected virtual void SetUnit(List<Unit> selectedUnit, Unit rival)
    {
    }

    public Unit GetActiveUnit(int no = 0)
    {
        if (!activeUnits[no].IsDead)
            return activeUnits[no];
        else
        {
            return GetActiveUnit(no + 1);
        }
    }

    public bool IsAllUnitsDead()
    {
        for (int i = 0; i < activeUnits.Count; i++)
        {
            if (!activeUnits[i].IsDead) return false;
        }

        return true;
    }
}