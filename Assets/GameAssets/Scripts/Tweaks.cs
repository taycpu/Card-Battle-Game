using System.Collections.Generic;
using UnityEngine;

public static class Tweaks
{
    public static T GetRandom<T>(this List<T> element)
    {
        return element[Random.Range(0, element.Count)];
    }
}