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
    public Sprite completedImage;
    public Sprite failedImage;
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
                resultScore.GetComponent<Text>().text = scoreScript.resultScore.ToString();
                break;
            }
        }
    }
    
    IEnumerator ResultSpriteCoroutine()
    {
        while(true)
        {
            yield return null;
            if(inGameManager.orderOfShot - 1 == 9 && scoreScript.resultScore > counterScoreScript.resultScoreOfCounter)
            {
                resultImage.GetComponent<Image>().sprite = completedImage;
                break;
            }
            
            else if(inGameManager.orderOfShot - 1 == 9 && scoreScript.resultScore <= counterScoreScript.resultScoreOfCounter)
            {
                resultImage.GetComponent<Image>().sprite = failedImage;
                break;
            }
        }
    }
}
