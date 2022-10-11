using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroFactory : Factory
{
    [SerializeField] private List<Transform> heroPlaces;

    private int placeCounter = 0;

    public override void Generate(int id, Action onAttackEnd)
    {
        base.Generate(id, onAttackEnd);
        units[id].Activate(heroPlaces[placeCounter].position, onAttackEnd);

        placeCounter++;
    }
}