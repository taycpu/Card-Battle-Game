using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}