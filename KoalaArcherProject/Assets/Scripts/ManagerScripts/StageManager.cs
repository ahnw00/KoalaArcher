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

        for (int i = 0; i <= saveData.indexOfStageCompleted; ++i)
        {
            stageBtnList[i].interactable = true;
        }

        if (stageList.Count == 0)
        {
            StageClass stage = new StageClass();
            stage.aimSpeed = 5;
            stage.powerGaugeSpeed = 2;
            stage.bestScore = 0;

            stageList.Add(stage);
        }
        else if (stageList.Count < saveData.indexOfStageCompleted)
        {
            StageClass stage = new StageClass();
            stage.aimSpeed = 5 + saveData.indexOfStageCompleted; // 수정 필요
            stage.powerGaugeSpeed = 2 + saveData.indexOfStageCompleted; // 수정 필요
            stage.bestScore = 0;

            stageList.Add(stage);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
