using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Btn : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    StageClass stage;
    public void ChangeScene()
    {
        SceneManager.LoadScene("GameScene");
        //saveData.currentStage = 
    }
}
