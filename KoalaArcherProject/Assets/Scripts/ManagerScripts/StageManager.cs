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

        for (int i = 0; i < saveData.indexOfStageCompleted + 1; i++)
        {
            if(i == 5)
            {
                break;
            }
            stageBtnList[i].interactable = true;
            
        }

        // @ aimspeed - 각도 조준선의 속도
        // @ powerGaugeSpeed - 파워 게이지가 줄어드는 속도
        // @ powerOfGauge - 한번 클릭했을때 파워 게이지가 차는 속도
        if (saveData.indexOfStageCompleted == 0 && stageList.Count == 0)
        {
            StageClass stage1 = new StageClass();
            stage1.aimSpeed = 250;
            stage1.powerGaugeSpeed = 2;
            stage1.powerOfGauge = 0.25f;
            stage1.bestScore = 0;
            stage1.timeLimit = 3;

            stageList.Add(stage1);

            StageClass stage2 = new StageClass();
            stage2.aimSpeed = 300;
            stage2.powerGaugeSpeed = 2;
            stage2.powerOfGauge = 0.2f;
            stage2.bestScore = 0;
            stage2.timeLimit = 3;

            stageList.Add(stage2);

            StageClass stage3 = new StageClass();
            stage3.aimSpeed = 400;
            stage3.powerGaugeSpeed = 3;
            stage3.powerOfGauge = 0.25f;
            stage3.bestScore = 0;
            stage3.timeLimit = 3;

            stageList.Add(stage3);

            StageClass stage4 = new StageClass();
            stage4.aimSpeed = 450;
            stage4.powerGaugeSpeed = 3;
            stage4.powerOfGauge = 0.2f;
            stage4.bestScore = 0;
            stage4.timeLimit = 3;

            stageList.Add(stage4);

            StageClass stage5 = new StageClass();
            stage5.aimSpeed = 500;
            stage5.powerGaugeSpeed = 4;
            stage5.powerOfGauge = 0.2f;
            stage5.bestScore = 0;
            stage5.timeLimit = 3;

            stageList.Add(stage5);
            gameManager.Save();
        }
    }
}
