using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroCardUI : MonoBehaviour
{
    public bool IsInfoActive => infoPopup.activeInHierarchy;
    [SerializeField] private GameObject infoPopup;
    [SerializeField] private Text heroNameText;
    [SerializeField] private Text attackPowerText;
    [SerializeField] private Text experienceText;
    [SerializeField] private Text levelText;
    [SerializeField] private Image img;
    
    public void Initialize(HeroAttribute heroAttribute)
    {
        if (heroAttribute == null) return;

        heroNameText.text = heroAttribute.heroName;
        attackPowerText.text = heroAttribute.attackPower.ToString();
        experienceText.text = heroAttribute.experience.ToString();
        levelText.text = heroAttribute.level.ToString();
        levelText.text = heroAttribute.level.ToString();
        img.color = heroAttribute.color;
    }

    public void InfoPopup(bool active)
    {
        infoPopup.SetActive(active);
    }
}