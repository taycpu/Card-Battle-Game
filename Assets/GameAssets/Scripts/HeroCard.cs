using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsUnlocked => heroAttribute.IsUnlocked;

    [SerializeField] private HeroCardUI heroCardUi;
    [SerializeField] private Image outline;
    [SerializeField] private HeroAttribute heroAttribute;

    private const float C_infoPopupTime = 2f;
    private bool isPicked;
    private bool canOpen;
    private float pressedTime;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        heroCardUi.Initialize(heroAttribute);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0) || !isPicked) return;

        if (Time.time - pressedTime > C_infoPopupTime && canOpen)
        {
            canOpen = false;
            heroCardUi.InfoPopup(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isPicked)
        {
            Pick();
            canOpen = true;
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
        HeroInventory.Instance.UnPickHero(heroAttribute);
    }

    private void Pick()
    {
        HeroInventory.Instance.PickHero(heroAttribute);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer up" + heroCardUi.IsInfoActive);
        if (!canOpen)
        {
            heroCardUi.InfoPopup(false);
        }
    }
}