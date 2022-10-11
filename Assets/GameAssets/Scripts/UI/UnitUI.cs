using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class UnitUI : MonoBehaviour
    {
        [SerializeField] private Image health;


        public void UpdateHealth(double amount)
        {
            health.fillAmount = (float)amount;
        }
    }
}