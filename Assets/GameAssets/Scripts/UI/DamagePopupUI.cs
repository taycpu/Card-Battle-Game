using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DamagePopupUI : MonoBehaviour
{
    public static DamagePopupUI Instance;

    [SerializeField] private Text dmgText;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);
        Instance = this;
    }


    public void SetDamagePopup(Vector3 pos, double dmg)
    {
        dmgText.text = dmg.ToString();
        dmgText.color = Color.white;
        transform.position = pos + new Vector3(0, 3, 0);
        DOVirtual.DelayedCall(0.2f, () => dmgText.DOFade(0, 0.2f));
    }
}