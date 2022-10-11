using System.Collections.Generic;
using GameAssets.Scripts.Misc;
using GameAssets.Scripts.Units;

namespace GameAssets.Scripts.Controllers
{
    public class EnemyController : UnitController
    {
        protected override void SetUnit(List<Unit> selectedUnit, Unit rival)
        {
            var randomUnit = selectedUnit.GetRandom();
            randomUnit.Attack(rival);
        }
    }
}