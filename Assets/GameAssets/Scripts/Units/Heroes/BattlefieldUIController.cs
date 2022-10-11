using System.Collections.Generic;
using UnityEngine;

namespace GameAssets.Scripts.Units.Heroes
{
    public class BattlefieldUIController : MonoBehaviour
    {
        [SerializeField] private List<UIScreen> uiScreens;

        public void Activate(int index)
        {
            uiScreens[index].Enable();
        }
    
    }
}