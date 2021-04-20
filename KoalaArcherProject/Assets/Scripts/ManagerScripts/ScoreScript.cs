using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public InGameManager inGameManager;
    public Text textprefab;
    Text scoreText;
  
    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
    }

    //한 번의 슈팅이 끝났을 때 점수가 점수판 위에 뜨도록 해주는 함수
    public void InstantiationOfScoreText()
    {
        scoreText = Instantiate(textprefab, this.transform);
        scoreText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-295 + 71.66f * (inGameManager.orderOfShot - 1), 31, 0);
        scoreText.text = inGameManager.scoreList[inGameManager.orderOfShot - 1].ToString();
    }
}
