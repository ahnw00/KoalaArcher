using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSaveBtn : MonoBehaviour
{
    GameManager gameManager;
    SoundManager soundManager;
    SaveDataClass saveData;

    public void LoadCutScene()
    {
        gameManager = GameManager.singleTon;
        gameManager.saveData = new SaveDataClass();
        saveData = gameManager.saveData;
        saveData.isFirstTimeOfPlay = false;
        saveData = gameManager.saveData;

        soundManager = SoundManager.inst;
        gameManager.Save();
        soundManager.ButtonEffectPlay();
        soundManager.StageBGMPlay();
        SceneLoadManager.instance.LoadScene("CutScene");
    }
    public void LoadStageScene()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;

        soundManager = SoundManager.inst;
        soundManager.ButtonEffectPlay();
        soundManager.StageBGMPlay();
        SceneLoadManager.instance.LoadScene("StageScene");
    }
}
