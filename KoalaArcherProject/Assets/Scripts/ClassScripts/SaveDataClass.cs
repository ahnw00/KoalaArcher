using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[System.Serializable]
public class SaveDataClass
{
    public List<StageClass> stageList;
    public StageClass currentSelectedStage;
    public bool isFirstTimeOfPlay;
    public int indexOfStageCompleted;
    public int currentStageIndex;

    public SaveDataClass()
    {
        stageList = new List<StageClass>();
        currentSelectedStage = null;
        currentStageIndex = 0;

        isFirstTimeOfPlay = true;
        indexOfStageCompleted = 0;
    }
}