using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSaveBtn : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    public void LoadCutScene()
    {
        gameManager = GameManager.singleTon;
        gameManager.saveData=new SaveDataClass();
        saveData=gameManager.saveData;
        saveData.isFirstTimeOfPlay=false;
        saveData=gameManager.saveData;
        gameManager.Save();
        SceneLoadManager.instance.LoadScene("CutScene");
    }
    public void LoadStageScene()
    {
        gameManager= GameManager.singleTon;
        saveData=gameManager.saveData;
        SceneLoadManager.instance.LoadScene("StageScene");
    }
}
