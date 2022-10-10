public class PlayerController : UnitController
{
    public void LockOtherUnits()
    {
        for (int i = 0; i < activeUnits.Count; i++)
        {
            activeUnits[i].SetBusy();
        }
    }
}