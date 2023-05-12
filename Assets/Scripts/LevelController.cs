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

    public int numberOfStages;
    public float spaceBetweenY;
    
    public void Init()
    {
        GameData gameData = GameController.Instance.gameData;
        List<PlatformPatternData> listPattern = gameData.platformPatternDatas;
        //Duyệt qua từng tầng
        for (int i = 0; i <= numberOfStages; i++)
        {
            PlatformPatternData chosenPattern = listPattern[(int)Random.Range(0, listPattern.Count)];

            float randomOffsetAngle = Random.Range(-5f, 5f);
            //Duyệt hết 1 vòng 360 độ
            for (int j = 0; j < 16; j++)
            {
                Transform platformTransform = Instantiate(platformPrefab, column);
                Vector3 pos = new Vector3(0, -i, 0);
                platformTransform.position = pos;
                platformTransform.rotation = Quaternion.Euler(0, 22.5f * j + randomOffsetAngle, 0);
                
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
                        platformTransform.gameObject.tag = "Hazard";
                        break;
                    }
                }
                
                //Xét tầng 1
                if (i == 0 && j == 0)
                {
                    if (platformTransform.gameObject.activeInHierarchy == false)
                    {
                        platformTransform.gameObject.SetActive(true);
                        platformTransform.GetComponent<MeshRenderer>().material.color = Color.black;
                        platformTransform.gameObject.tag = "Normal";
                    }
                }
            }
        }
        
        Vector3 posDest = new Vector3(0, - numberOfStages - 1, 0);
        for (int j = 0; j < 16; j++)
        {
            Transform platformTransform = Instantiate(platformPrefab, column);
            platformTransform.position = posDest;
            platformTransform.rotation = Quaternion.Euler(0, 22.5f * j, 0);
            if (j % 2 == 0)
            {
                platformTransform.GetComponent<MeshRenderer>().material.color = Color.black;
            }
            else
            {
                platformTransform.GetComponent<MeshRenderer>().material.color = Color.white;
            }
            platformTransform.gameObject.tag = "Destination";
        }
    }
}
