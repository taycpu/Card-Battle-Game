using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;



    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }
    
}