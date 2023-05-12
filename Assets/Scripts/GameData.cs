using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<PlatformPatternData> platformPatternDatas;
    
    //Property
    public static int HighestScore{
        get
        {
            return PlayerPrefs.GetInt(StringHelper.HIGHEST_SCORE, 0);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.HIGHEST_SCORE, value);
        }
    }

    void T()
    {
        HighestScore = 5;
    }
}

[System.Serializable]
public class PlatformPatternData
{
    public List<PlatformType> data;
}

public enum PlatformType
{
    Empty = 0,
    Normal = 1,
    Hazard = 2
}
