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
    [SerializeField] private HeroInventory heroInventory;

    private const float C_infoPopupTime = 1f;
    private bool isPicked;
    private bool canPopupOpen;
    private float pressedTime;

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
        heroInventory.UnPickHero(characterAttribute);
    }

    private void Pick()
    {
        heroInventory.PickHero(characterAttribute);
        canPopupOpen = true;
        pressedTime = Time.time;
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