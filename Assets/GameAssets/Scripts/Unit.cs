using System;
using DG.Tweening;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected Unit rival;
    [SerializeField] private CharacterAttribute characterAttribute;

    public bool readyToAttack;
    public bool IsDead => isDead;
    public int health;
    private bool isDead;
    private Vector3 startPos;
    private Action onAttackComplete;

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public void AssignRival(Unit rival)
    {
        this.rival = rival;
        readyToAttack = true;
    }

    public virtual void Attack(Unit unit)
    {
        transform.DOMove(unit.transform.position, 0.3f).OnComplete(() => DOVirtual.DelayedCall(0.2f, CompleteAttack));
    }

    public virtual void CompleteAttack()
    {
        transform.DOMove(startPos, 0.2f).OnComplete(() => onAttackComplete?.Invoke());
        rival.TakeDamage(characterAttribute.attackPower);
        readyToAttack = false;
    }

    public virtual void Activate(Vector3 startPos, Action onAttackEnd)
    {
        health = characterAttribute.health;
        this.startPos = startPos;
        transform.position = startPos;
        gameObject.SetActive(true);

        onAttackComplete = onAttackEnd;
    }

    protected virtual void Die()
    {
        Debug.Log("Die");
        isDead = true;
    }

    public abstract void Clicked();
}