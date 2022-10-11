using UnityEngine;

namespace GameAssets.Scripts.Units.Heroes
{
    public abstract class HeroObject : Unit
    {
        public virtual void Clicked()
        {
            if (!readyToAttack) return;
            Attack(rival);
        }
    }
}