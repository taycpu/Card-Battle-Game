using System.Collections.Generic;
using UnityEngine;

public class BattlefieldUIController : MonoBehaviour
{
    [SerializeField] private List<UIScreen> uiScreens;

    public void Activate(int index)
    {
        uiScreens[index].Enable();
    }
    
}