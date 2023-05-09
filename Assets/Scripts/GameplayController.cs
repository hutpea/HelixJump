using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController Instance;

    public LevelController levelController;
    public GameplayUIController gameplayUIController;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        OnAwake();
    }

    private void OnAwake()
    {
        levelController.Init();
    }
}
