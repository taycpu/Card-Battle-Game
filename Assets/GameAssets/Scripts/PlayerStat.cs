using UnityEngine;


[CreateAssetMenu(menuName = "Create PlayerStat", fileName = "PlayerStat", order = 0)]
public class PlayerStat : ScriptableObject
{
    public int WinCount { get; private set; }
    public int LoseCount { get; private set; }
    
    
    
}