using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Manager[] managers;

    private void Awake()
    {
        SaveManager.ReadFile(onComplete:InitAllManagers);
    }

    private void InitAllManagers()
    {
        for (int i = 0; i < managers.Length; i++)
        {
            managers[i].Initialize();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveManager.Save("Balbasaur", 13);
        }
    }
}