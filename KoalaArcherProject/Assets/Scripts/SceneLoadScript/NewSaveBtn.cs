using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NewSaveBtn : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    public void LoadCutScene()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        SceneLoadManager.instance.LoadScene("CutScene");
    }
    public void LoadStageScene()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        SceneLoadManager.instance.LoadScene("StageScene");
    }
    public void SetFirstOfPlay()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        saveData.isFirstTimeOfPlay = false;
    }
    
}
