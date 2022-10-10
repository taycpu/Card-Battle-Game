using UnityEngine;

public abstract class Enemy : Unit
{
    public override void Clicked()
    {
        Debug.Log("Clicked Enemy = "+transform.name);
    }
}