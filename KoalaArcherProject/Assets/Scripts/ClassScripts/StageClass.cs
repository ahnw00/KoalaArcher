using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class StageClass
{
    public int scoreOfCounterpart;
    public float aimSpeed;
    public float powerOfGauge;
    public int numberOfShot;
    public int bestScore;

    public StageClass()
    {
        scoreOfCounterpart = 0;
        aimSpeed = 0;
        powerOfGauge = 0;
        numberOfShot = 10;
        bestScore = 0;
    }
}