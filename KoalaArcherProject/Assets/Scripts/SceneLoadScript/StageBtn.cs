using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageBtn : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    StageClass stage;
    public void ChangeScene()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;

        SceneManager.LoadScene("GameScene");
        
        for(int i = 0; i < 5; i++)
        {
            if(this == this.transform.parent.GetChild(i + 1))
            {
                stage = saveData.stageList[i];
                saveData.currentStage = stage;
            }
        }
    }
}
