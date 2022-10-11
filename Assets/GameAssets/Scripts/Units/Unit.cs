using System;
using DG.Tweening;
using GameAssets.Scripts.SO_Containers;
using GameAssets.Scripts.Units.Heroes;
using UnityEngine;

namespace GameAssets.Scripts.Units
{
    public abstract class Unit : MonoBehaviour, IInfoPopup
    {
        public bool IsDead => isDead;


        public CharacterAttribute characterAttribute;
        protected double health;
        protected Unit rival;
        protected bool readyToAttack;

        [SerializeField] private MeshRenderer mesh;
        private bool isDead;
        private Vector3 startPos;
        private Action onAttackComplete;

        public virtual void TakeDamage(double dmg)
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
            readyToAttack = false;
            transform.DOMove(unit.transform.position, 0.3f)
                .OnComplete(() => DOVirtual.DelayedCall(0.2f, CompleteAttack));
        }

        protected virtual void CompleteAttack()
        {
            transform.DOMove(startPos, 0.2f).OnComplete(() => onAttackComplete?.Invoke());
            rival.TakeDamage(characterAttribute.AttackPower);
        }

        public virtual void Activate(Vector3 startPos, Action onAttackEnd)
        {
            health = characterAttribute.Health;
            this.startPos = startPos;
            transform.position = startPos;
            gameObject.SetActive(true);
            mesh.material.color = characterAttribute.Color;
            onAttackComplete = onAttackEnd;
        }

        protected virtual void Die()
        {
            Debug.Log("Die");
            isDead = true;
            transform.DOScale(Vector3.zero, 0.2f);
        }


        public CharacterAttribute GetCharacterAttributes()
        {
            return characterAttribute;
        }

        public void SetBusy()
        {
            readyToAttack = false;
        }
    }
}