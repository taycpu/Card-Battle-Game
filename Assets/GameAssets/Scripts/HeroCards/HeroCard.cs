using GameAssets.Scripts.SO_Containers;
using GameAssets.Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameAssets.Scripts.HeroCards
{
    public class HeroCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsUnlocked => characterAttribute.IsUnlocked;

        [SerializeField] private PopupInfoUI popupInfoUI;
        [SerializeField] private Image outline;
        [SerializeField] private CharacterAttribute characterAttribute;
        [SerializeField] private HeroInventory heroInventory;

        private const float C_infoPopupTime = 1f;
        private const int C_MaxSelectable = 3;
        private bool isPicked;
        private bool canPopupOpen;
        private float pressedTime;

        public void Initialize()
        {
            popupInfoUI.Initialize(characterAttribute);
        }

        private void Update()
        {
            if (!Input.GetMouseButton(0) || !isPicked) return;

            if (Time.time - pressedTime > C_infoPopupTime && canPopupOpen)
            {
                canPopupOpen = false;
                popupInfoUI.SetActive(true);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!isPicked)
            {
                Pick();
            }
            else
            {
                Unpick();
            }
        }

        private void Unpick()
        {
            heroInventory.UnPickHero(characterAttribute);
            isPicked = false;
            outline.enabled = false;
        }

        private void Pick()
        {
            if (heroInventory.PickedHeroes.Count >= C_MaxSelectable) return;
            heroInventory.PickHero(characterAttribute);
            canPopupOpen = true;
            pressedTime = Time.time;
            isPicked = true;
            outline.enabled = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!canPopupOpen)
            {
                popupInfoUI.SetActive(false);
            }
            else
            {
                canPopupOpen = false;
            }
        }
    }
}