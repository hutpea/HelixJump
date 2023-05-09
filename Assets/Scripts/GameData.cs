using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<PlatformPatternData> platformPatternDatas;
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
