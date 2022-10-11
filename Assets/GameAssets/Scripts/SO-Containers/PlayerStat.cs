using UnityEngine;

namespace GameAssets.Scripts.SO_Containers
{
    [CreateAssetMenu(menuName = "Create PlayerStat", fileName = "PlayerStat", order = 0)]
    public class PlayerStat : ScriptableObject
    {
        public int WinCount;
        public int LoseCount;


        public void Win()
        {
            WinCount++;
        }

        public void Lose()
        {
            LoseCount++;
        }
    }
}