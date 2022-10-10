using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroFactory : Factory
{
    [SerializeField] private List<Transform> heroPlaces;


    public override void Generate(int id, Action onAttackEnd)
    {
        base.Generate(id, onAttackEnd);
        units[id].Activate(heroPlaces[id].position, onAttackEnd);
    }
}