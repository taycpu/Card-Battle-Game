using System.Collections.Generic;
using UnityEngine;

public abstract class UnitController : MonoBehaviour
{
    [SerializeField] private List<Unit> activeUnits;

    public void SetActiveUnits(List<Unit> units)
    {
        activeUnits = units;
    }  
    public void GetReadyForTurn(Unit rivalUnit)
    {
        for (int i = 0; i < activeUnits.Count; i++)
        {
            activeUnits[i].AssignRival(rivalUnit);

            //TODO: Player should be get ready for attack.Also gameInputController class will not change because it can click any object in area which is clickable
        }

        SetUnit(activeUnits, rivalUnit);
    }

    protected virtual void SetUnit(List<Unit> selectedUnit, Unit rival)
    {
        
    }

    public Unit GetActiveUnit(int no = 0)
    {
        return activeUnits[0];
        /*  if (activeUnits[no].IsDead)
              return activeUnits[no];
          else
          {
              return GetActiveUnit(no + 1);
          }
          */
    }
}