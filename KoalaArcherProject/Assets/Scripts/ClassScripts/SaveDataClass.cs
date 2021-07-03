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
    public float volumeOfBgm;
    public float volumeOfEffect;

    public SaveDataClass()
    {
        stageList = new List<StageClass>();
        currentSelectedStage = null;
        currentStageIndex = 0;

        isFirstTimeOfPlay = true;
        indexOfStageCompleted = 0;

        volumeOfBgm = 0.5f;
        volumeOfEffect = 0.5f;
    }
}
