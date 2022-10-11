using GameAssets.Scripts.SO_Containers;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class PopupInfoUI : MonoBehaviour
    {
        public bool IsInfoActive => infoPopup.activeInHierarchy;
        [SerializeField] private GameObject infoPopup;
        [SerializeField] private Text heroNameText;
        [SerializeField] private Text attackPowerText;
        [SerializeField] private Text experienceText;
        [SerializeField] private Text levelText;
        [SerializeField] private Image img;
    
        public void Initialize(CharacterAttribute characterAttribute)
        {
            if (characterAttribute == null) return;

            heroNameText.text = characterAttribute.HeroName;
            attackPowerText.text = characterAttribute.AttackPower.ToString();
            experienceText.text = characterAttribute.Experience.ToString();
            levelText.text = characterAttribute.Level.ToString(); 
            img.color = characterAttribute.Color;
        }

        public void SetActive(bool active)
        {
            infoPopup.SetActive(active);
        }
    }
}