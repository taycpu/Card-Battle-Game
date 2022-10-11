using System;
using GameAssets.Scripts.Misc;
using UnityEngine;

namespace GameAssets.Scripts.SO_Containers
{
    [CreateAssetMenu(menuName = "Characters/Hero", fileName = "Character", order = 0)]
    public class CharacterAttribute : ScriptableObject
    {
        #region Attributes

        public bool IsUnlocked;
        public string HeroName => heroName;
        public Color Color => color;
        public int HeroId => heroId;
        public double Health => health;
        public double AttackPower => attackPower;
        public int Experience => experience;
        public int Level => level;

        #endregion


        [SerializeField] private string heroName;
        [SerializeField] private Color color;
        [SerializeField] private int heroId;
        [SerializeField] private double health;
        [SerializeField] private double attackPower;
        [SerializeField] private int experience;
        [SerializeField] private int level;


        public void Unlock()
        {
            IsUnlocked = true;
            SaveManager.Save(heroName + "unlock", 1);
        }

        public void Load()
        {
            if (SaveManager.GetValue(heroName + "unlock", out var unlocked))
            {
                IsUnlocked = Convert.ToBoolean(unlocked);
            }

            if (SaveManager.GetValue(heroName + "level", out var lvl))
            {
                level = (int)lvl;
            }

            if (SaveManager.GetValue(heroName + "experience", out var expr))
            {
                experience = (int)expr;
            }

            if (SaveManager.GetValue(heroName + "health", out var hlth))
            {
                health = hlth;
            }

            if (SaveManager.GetValue(heroName + "attackPower", out var aP))
            {
                attackPower = aP;
            }
        }


        public void TakeExperience(int amount)
        {
            experience += amount;
            if (experience >= 5)
            {
                experience = 0;
                LevelUp();
            }

            SaveManager.Save(heroName + "experience", experience);
        }

        private void LevelUp()
        {
            level++;
            health += health / 10;
            attackPower += attackPower / 10f;
            SaveManager.Save(heroName + "level", level);
            SaveManager.Save(heroName + "health", health);
            SaveManager.Save(heroName + "attackPower", attackPower);
        }
    }
}