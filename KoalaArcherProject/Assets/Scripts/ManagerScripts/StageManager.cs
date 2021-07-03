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
            StageClass stage1 = new StageClass();
            stage1.aimSpeed = 110;
            stage1.powerGaugeSpeed = 2;
            stage1.bestScore = 0;
            stage1.timeLimit = 3;

            stageList.Add(stage1);
            gameManager.Save();

            StageClass stage2 = new StageClass();
            stage2.aimSpeed = 120;
            stage2.powerGaugeSpeed = 2;
            stage2.bestScore = 0;
            stage2.timeLimit = 3;

            stageList.Add(stage2);
            gameManager.Save();

            StageClass stage3 = new StageClass();
            stage3.aimSpeed = 130;
            stage3.powerGaugeSpeed = 2;
            stage3.bestScore = 0;
            stage3.timeLimit = 3;

            stageList.Add(stage3);
            gameManager.Save();

            StageClass stage4 = new StageClass();
            stage4.aimSpeed = 140;
            stage4.powerGaugeSpeed = 2;
            stage4.bestScore = 0;
            stage4.timeLimit = 3;

            stageList.Add(stage4);
            gameManager.Save();

            StageClass stage5 = new StageClass();
            stage5.aimSpeed = 150;
            stage5.powerGaugeSpeed = 2;
            stage5.bestScore = 0;
            stage5.timeLimit = 3;

            stageList.Add(stage5);
            gameManager.Save();
        }
    }
}
