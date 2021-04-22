using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreAndImage : MonoBehaviour
{
    InGameManager inGameManager;
    ScoreScript scoreScript;
    CounterKoala counterScoreScript;
    public Text resultScore;
    public GameObject resultImage;
    public Image completedImage;
    public Image failedImage;
    void Start()
    {
        inGameManager=FindObjectOfType<InGameManager>();
        scoreScript=FindObjectOfType<ScoreScript>();
        counterScoreScript=FindObjectOfType<CounterKoala>();
        StartCoroutine(ResultCoroutine());
        StartCoroutine(ResultSpriteCoroutine());
    }

    IEnumerator ResultCoroutine()
    {
        while(true)
        {
            yield return null;
            if(inGameManager.orderOfShot - 1 == 9)
            {
                resultScore.Text = scoreScript.resultScore.ToString();
                break;
            }
        }
    }
    
    IEnumerator ResultSpriteCoroutine(){
        while(true)
        {
            yield return null;
            if(inGameManager.orderOfShot - 1 == 9 && scoreScript.resultScore > counterScoreScript.resultScoreOfCounter)
            {
                resultImage.Image = completedImage;
                break;
            }
            
            else if(inGameManager.orederOfShot - 1 == 9 && scoreScript.resultScore <= counterScoreScript.resultScoreOfCounter)
            {
                resultImage.Image=failedImage;
                break;
            }
        }
    }
}
