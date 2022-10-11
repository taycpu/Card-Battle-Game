using System.Collections.Generic;

public class PlayerController : UnitController
{
    public void LockOtherUnits()
    {
        for (int i = 0; i < activeUnits.Count; i++)
        {
            activeUnits[i].SetBusy();
        }
    }

    public List<Unit> GetLiveUnits()
    {
        return activeUnits.FindAll(u => !u.IsDead);
    }
}