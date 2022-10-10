using System.Collections.Generic;
using UnityEngine;

public class HeroFactory : Factory
{
    public List<HeroObject> HeroObjects;
    [SerializeField] private List<Transform> heroPlaces;

    public override void Generate(int id)
    {
        HeroObjects[id].Activate(heroPlaces[id].position);
    }
}