using UnityEngine;


public abstract class HeroObject : Unit
{
    [SerializeField] protected HeroAttribute heroAttribute;


    public override void Activate(Vector3 startPos)
    {
        health = heroAttribute.health;
    }


    public void Clicked()
    {
        Debug.Log("Clicked =" + transform.name);
    }
}