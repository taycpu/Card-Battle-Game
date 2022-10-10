using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsUnlocked => characterAttribute.IsUnlocked;

    [SerializeField] private HeroCardUI heroCardUi;
    [SerializeField] private Image outline;
    [SerializeField] private CharacterAttribute characterAttribute;

    private const float C_infoPopupTime = 1f;
    private bool isPicked;
    private bool canPopupOpen;
    private float pressedTime;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        heroCardUi.Initialize(characterAttribute);
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0) || !isPicked) return;

        if (Time.time - pressedTime > C_infoPopupTime && canPopupOpen)
        {
            canPopupOpen = false;
            heroCardUi.InfoPopup(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isPicked)
        {
            Pick();
            canPopupOpen = true;
            pressedTime = Time.time;
        }
        else
        {
            Unpick();
        }

        isPicked = !isPicked;
        outline.enabled = isPicked;

        Debug.Log("IS PICKED=" + isPicked);
    }

    private void Unpick()
    {
        HeroInventory.Instance.UnPickHero(characterAttribute);
    }

    private void Pick()
    {
        HeroInventory.Instance.PickHero(characterAttribute);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer up" + heroCardUi.IsInfoActive);
        if (!canPopupOpen)
        {
            heroCardUi.InfoPopup(false);
        }
        else
        {
            canPopupOpen = false;
        }
    }
}