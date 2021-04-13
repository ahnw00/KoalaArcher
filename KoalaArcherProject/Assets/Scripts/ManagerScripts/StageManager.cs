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

        if(stageList.Count == 0)
        {
            StageClass stage = new StageClass();
            stage.aimSpeed = 5;
            stage.bestScore = 0;

            stageList.Add(stage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
