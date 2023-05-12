using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    //Other controllers
    //AdsController
    //IapController
    public SoundController soundController;
    public GameData gameData;
    public PrefabLoader prefabLoader;
    
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
        DontDestroyOnLoad(Instance.gameObject);

        OnAwake();
    }

    private void OnAwake()
    {
        //Khoi tao controller
        
        SceneManager.LoadScene("Gameplay");
    }
}
