using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public bool IsDead => isDead;
    public int health;
    private bool isDead;
    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Attack(Unit unit)
    {
    }

    public void CompleteAttack()
    {
      //  taggedEnemy.TakeDamage(heroAttribute.attackPower);
    }
    public virtual void Activate(Vector3 startPos)
    {
        transform.position = startPos;
        gameObject.SetActive(true);
    }

    protected virtual void Die()
    {
        Debug.Log("Die");
        isDead = true;
    }
}