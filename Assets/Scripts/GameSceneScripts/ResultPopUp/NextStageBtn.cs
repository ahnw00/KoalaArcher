using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageBtn : MonoBehaviour
{
    GameManager gameManager;
    public SaveDataClass saveData;
    SoundManager soundManager;
    ScoreScript scoreScript;
    CounterKoala counterScoreScript;

    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        soundManager = SoundManager.inst;

        scoreScript = FindObjectOfType<ScoreScript>();
        counterScoreScript = FindObjectOfType<CounterKoala>();
    }

    public void NextStage()
    {
        if (saveData.currentStageIndex == 4 && scoreScript.resultScore > counterScoreScript.resultScoreOfCounter)
        {
            soundManager.SecondButtonPlay();
            soundManager.StageBGMPlay();
            SceneLoadManager.instance.LoadScene("EndingScene");
        }

        else if(saveData.currentStageIndex <= 3 && scoreScript.resultScore > counterScoreScript.resultScoreOfCounter)
        {
            soundManager.SecondButtonPlay();
            soundManager.StageBGMPlay();
            SceneLoadManager.instance.LoadScene("EpisodeCutScene");
        }
        
        else
        {
            soundManager.SecondButtonPlay();
            soundManager.StageBGMPlay();
            SceneLoadManager.instance.LoadScene("StageScene");
        }
    }
}
