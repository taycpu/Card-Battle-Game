using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Image timeCircle;

        public void Activate(bool enabled)
        {
            if (enabled)
            {
                transform.DOScale(Vector3.one, 0.1f);
            }
            else
            {
                transform.DOScale(Vector3.zero, 0.1f);
            }
        }

        public void FillCircle(float amount)
        {
            timeCircle.fillAmount = amount;
        }
    }
}