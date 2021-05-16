using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    List<StageClass> stageList;
    public List<Button> stageBtnList;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        stageList = saveData.stageList;

        for (int i = 0; i <= saveData.indexOfStageCompleted; i++)
        {
            stageBtnList[i].interactable = true;
        }

        if (saveData.indexOfStageCompleted == 0 && stageList.Count == 0)
        {
            StageClass stage = new StageClass();
            stage.aimSpeed = 100;
            stage.powerGaugeSpeed = 2;
            stage.bestScore = 0;
            stage.timeLimit = 3;

            stageList.Add(stage);
            gameManager.Save();
        }
        else if (saveData.indexOfStageCompleted == 1 && stageList.Count == 1)
        {
            StageClass stage = new StageClass();
            stage.aimSpeed = 100;
            stage.powerGaugeSpeed = 2;
            stage.bestScore = 0;
            stage.timeLimit = 3;

            stageList.Add(stage);
            gameManager.Save();
        }
        else if (saveData.indexOfStageCompleted == 2 && stageList.Count == 2)
        {
            StageClass stage = new StageClass();
            stage.aimSpeed = 100;
            stage.powerGaugeSpeed = 2;
            stage.bestScore = 0;
            stage.timeLimit = 3;

            stageList.Add(stage);
            gameManager.Save();
        }
        else if (saveData.indexOfStageCompleted == 3 && stageList.Count == 3)
        {
            StageClass stage = new StageClass();
            stage.aimSpeed = 100;
            stage.powerGaugeSpeed = 2;
            stage.bestScore = 0;
            stage.timeLimit = 3;

            stageList.Add(stage);
            gameManager.Save();
        }
        else if (saveData.indexOfStageCompleted == 4 && stageList.Count == 4)
        {
            StageClass stage = new StageClass();
            stage.aimSpeed = 100;
            stage.powerGaugeSpeed = 2;
            stage.bestScore = 0;
            stage.timeLimit = 3;

            stageList.Add(stage);
            gameManager.Save();
        }
    }
}
