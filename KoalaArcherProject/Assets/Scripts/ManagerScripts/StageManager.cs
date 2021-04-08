using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    List<StageClass> stageList;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        stageList = saveData.stageList;

        if(stageList[0] == null)
        {
            stageList[0] = new StageClass();
            stageList[0].aimSpeed = 0;
            stageList[0].bestScore = 0;

            //stageList.Add(stageList[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
