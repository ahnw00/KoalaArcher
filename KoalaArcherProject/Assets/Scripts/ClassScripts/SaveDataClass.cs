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
    public StageClass currentSelectedStage;
    public bool isFirstTimeOfPlay;
    public int indexOfStageCompleted;
    public int currentStageIndex;
    public float volumeOfBgm;
    public float volumeOfEffect;

    public SaveDataClass()
    {
        stageList = new List<StageClass>();
        currentSelectedStage = null;
        currentStageIndex = 0;

        isFirstTimeOfPlay = true;
        indexOfStageCompleted = 0;
        
        volumeOfBgm = (float)0.5;
        volumeOfEffect = (float)0.5;
    }
}