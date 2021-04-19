using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageBtn : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    public List<GameObject> stageBtnList;
    
    public void ChangeScene()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        
        for(int i = 0; i < 5; i++)
        {
            if(this.gameObject == stageBtnList[i])
            {
                saveData.currentSelectedStage = saveData.stageList[i];
            }
        }

        SceneLoadManager.instance.LoadScene("GameScene");
    }
}
