using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageBtn : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    StageClass stage;
    public List<GameObject> stageBtnList;
    public void ChangeScene()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        
        for(int i = 0; i < 5; i++)
        {
            if(this.gameObject == stageBtnList[i])
            {
                stage = saveData.stageList[i];
                saveData.currentStage = stage;
            }
        }

        SceneManager.LoadScene("GameScene");
    }
}
