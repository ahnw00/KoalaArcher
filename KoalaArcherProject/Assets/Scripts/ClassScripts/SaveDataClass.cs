using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//여기다가 새로하기 이어하기에 대한 정보(첫 플레이인지 아닌지)
//


[System.Serializable]
public class SaveDataClass
{
    public List<StageClass> stageList;
    public StageClass currentStage;
    public bool isFirstTimeOfPlay;
    public int indexOfStageCompleted;
        
    public SaveDataClass()
    {
        stageList = new List<StageClass>();
        currentStage = null;

        isFirstTimeOfPlay = true;
        indexOfStageCompleted = 0;
    }
}