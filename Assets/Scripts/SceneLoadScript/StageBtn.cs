using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageBtn : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    public List<GameObject> stageBtnList;
    SoundManager soundManager;

    public void ChangeScene()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        soundManager = SoundManager.inst;

        for (int i = 0; i < 5; i++)
        {
            if (this.gameObject == stageBtnList[i])
            {
                saveData.currentSelectedStage = saveData.stageList[i];
                saveData.currentStageIndex = i;
            }
        }

        soundManager.ButtonEffectPlay();
        soundManager.InGameBGMPlay();
        SceneLoadManager.instance.LoadScene("GameScene");
    }
}
