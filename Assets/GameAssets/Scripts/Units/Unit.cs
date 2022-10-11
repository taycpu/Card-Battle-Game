using System;
using DG.Tweening;
using GameAssets.Scripts.SO_Containers;
using GameAssets.Scripts.UI;
using GameAssets.Scripts.Units.Heroes;
using UnityEngine;
using Random = UnityEngine.Random;

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

        [SerializeField] private UnitUI unitUI;

        private bool isDead;
        private Vector3 startPos;
        private Action onAttackComplete;

        public virtual void Activate(Vector3 startPos, Action onAttackEnd)
        {
            health = characterAttribute.Health;
            this.startPos = startPos;
            transform.position = startPos;
            gameObject.SetActive(true);
            mesh.material.color = characterAttribute.Color;
            onAttackComplete = onAttackEnd;
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
            double randDmg = (characterAttribute.AttackPower * 1.8f - characterAttribute.AttackPower) * Random.value +
                             characterAttribute.AttackPower;
            randDmg = Math.Round(randDmg);
            DamagePopupUI.Instance.SetDamagePopup(rival.transform.position, randDmg);
            transform.DOMove(startPos, 0.2f).OnComplete(() => onAttackComplete?.Invoke());
            rival.TakeDamage(randDmg);
        }

        public virtual void TakeDamage(double dmg)
        {
            health -= dmg;
            unitUI.UpdateHealth(health / characterAttribute.Health);
            if (health <= 0)
            {
                Die();
            }
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