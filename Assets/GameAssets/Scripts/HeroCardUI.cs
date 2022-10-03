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


    public void Initialize(Hero hero)
    {
        if (hero == null) return;

        heroNameText.text = hero.heroName;
        attackPowerText.text = hero.attackPower.ToString();
        experienceText.text = hero.experience.ToString();
        levelText.text = hero.level.ToString();
        levelText.text = hero.level.ToString();
    }

    public void InfoPopup(bool active)
    {
        infoPopup.SetActive(active);
    }
}