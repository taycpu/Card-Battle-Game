using UnityEngine;


public abstract class HeroObject : MonoBehaviour
{
    protected HeroAttribute heroAttribute;
    public int health;

    public virtual void Activate()
    {
        gameObject.SetActive(true);
        health = heroAttribute.health;
    }

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Die");
    }

    public virtual void Attack(HeroObject enemy)
    {
        enemy.TakeDamage(heroAttribute.attackPower);
    }
}