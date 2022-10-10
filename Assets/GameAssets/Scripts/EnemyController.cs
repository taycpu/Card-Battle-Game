using System.Collections.Generic;

public class EnemyController : UnitController
{
    protected override void SetUnit(List<Unit> selectedUnit, Unit rival)
    {
        var randomUnit = selectedUnit.GetRandom();
        randomUnit.Attack(rival);
    }
}