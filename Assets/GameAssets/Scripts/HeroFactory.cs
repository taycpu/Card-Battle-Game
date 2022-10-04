using System.Collections.Generic;
using UnityEngine;

public class HeroFactory : MonoBehaviour
{
    public List<HeroObject> HeroObjects;

    public void GenerateHero(int id)
    {
        HeroObjects[id].Activate();
    }
}