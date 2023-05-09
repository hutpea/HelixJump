using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    public Transform platformPrefab;
    public Transform column;

    public void Init()
    {
        GameData gameData = GameController.Instance.gameData;
        List<PlatformPatternData> listPattern = gameData.platformPatternDatas;
        for (int i = 0; i <= 15; i++)
        {
            PlatformPatternData chosenPattern = listPattern[(int)Random.Range(0, listPattern.Count)];
            
            for (int j = 0; j < 16; j++)
            {
                Transform platformTransform = Instantiate(platformPrefab, column);
                Vector3 pos = new Vector3(0, -i, 0);
                platformTransform.position = pos;
                platformTransform.rotation = Quaternion.Euler(0, 22.5f * j, 0);
                
                switch (chosenPattern.data[j])
                {
                    case PlatformType.Empty:
                    {
                        platformTransform.gameObject.SetActive(false);
                        break;
                    }
                    case PlatformType.Normal:
                    {
                        platformTransform.GetComponent<MeshRenderer>().material.color = Color.black;
                        break;
                    }
                    case PlatformType.Hazard:
                    {
                        platformTransform.GetComponent<MeshRenderer>().material.color = Color.red;
                        break;
                    }
                }
            }
        }
    }
}
