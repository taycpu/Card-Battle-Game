using UnityEngine;


public abstract class HeroObject : Unit
{
    public virtual void Clicked()
    {
        if (!readyToAttack) return;
        Attack(rival);
        Debug.Log("Attacker name = " + transform.name);
    }
}