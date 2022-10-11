using GameAssets.Scripts.Misc;
using UnityEngine;

namespace GameAssets.Scripts.SO_Containers
{
    [CreateAssetMenu(menuName = "Create PlayerStat", fileName = "PlayerStat", order = 0)]
    public class PlayerStat : ScriptableObject
    {
        public int WinCount;
        public int LoseCount;


        public void Load()
        {
            if (SaveManager.GetValue("WinCount", out var wC))
            {
                WinCount = (int)wC;
            }

            if (SaveManager.GetValue("LoseCount", out var lc))
            {
                LoseCount = (int)lc;
            }


        }

        public void Win()
        {
            WinCount++;
            SaveManager.Save("WinCount", WinCount);
        }

        public void Lose()
        {
            LoseCount++;
            SaveManager.Save("LoseCount", LoseCount);
        }
    }
}