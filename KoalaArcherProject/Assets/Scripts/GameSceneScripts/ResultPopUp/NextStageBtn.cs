using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageBtn : MonoBehaviour
{
    GameManager gameManager;
    public SaveDataClass saveData;

    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
    }

    public void NextStage()
    {
        if (saveData.indexOfStageCompleted == 4)
        {
            SceneLoadManager.instance.LoadScene("EndingScene");
        }
        else
        {
            SceneLoadManager.instance.LoadScene("StageScene");
        }
    }
}
