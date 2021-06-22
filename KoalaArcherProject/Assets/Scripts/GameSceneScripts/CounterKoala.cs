using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterKoala : MonoBehaviour
{
    InGameManager inGameManager;
    TargetBoardManager targetBoardManager;
    public GameObject timeBar;
    public float timer;
    public float timeLimit;
    public int[,] counterScore;
    public int resultScoreOfCounter;
    public Text textPrefab;
    public GameObject textParent;
    public GameObject resultPopUp;
    public GameObject counterImage;
    ParamManager paramManager;
    Text scoreText;
    Text resultScore;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
        paramManager = inGameManager.myKoalaAnim.GetComponent<ParamManager>();
        targetBoardManager = FindObjectOfType<TargetBoardManager>();
        timeLimit = 3.8f;
        timer = 0;
        resultScoreOfCounter = 0;

        counterScore = new int[5, 10] {{0,6,6,6,7,8,8,9,10,10}, {6,6,6,7,7,8,8,8,9,10}, {0,6,7,8,9,10,10,10,10,10},
        {6,6,7,8,9,9,10,10,10,10}, {6,8,9,9,9,9,10,10,10,10}};

        ShuffleList(counterScore);
        StartCoroutine(CounterTimeBarCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator CounterTimeBarCoroutine()
    {
        while (true)
        {
            yield return null;

            if (!inGameManager.whileShooting)
            {
                //counterImage.SetActive(true);
                if (!inGameManager.isPaused)
                {
                    timer += Time.deltaTime;
                }

                timeBar.GetComponent<Image>().fillAmount = 1 - (timer / timeLimit);
                if (timer >= timeLimit && inGameManager.orderOfShot < 10)
                {
                    inGameManager.StartCoroutine(inGameManager.AngleAmingCoroutine());
                }
            }
            else if (inGameManager.whileShooting && timer >= timeLimit)
            {
                counterImage.SetActive(false);
                //꺼져있던 나의 코알라를 게임씬에서 다시 켜준다.
                inGameManager.myKoalaAnim.SetActive(true);
                paramManager.StartCoroutine(paramManager.MyKoalaAnim());

                timer = 0;
                timeBar.GetComponent<Image>().fillAmount = 1;
                scoreText = Instantiate(textPrefab, textParent.transform);
                scoreText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-295 + 71.66f * (inGameManager.orderOfShot - 1), -63, 0);
                scoreText.text = counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1].ToString();

                if (inGameManager.stage == inGameManager.saveData.stageList[0] || inGameManager.stage == inGameManager.saveData.stageList[3])
                {
                    targetBoardManager.gameObject.GetComponent<Image>().sprite = targetBoardManager.daytimeZero;
                }
                else if (inGameManager.stage == inGameManager.saveData.stageList[1])
                {
                    targetBoardManager.gameObject.GetComponent<Image>().sprite = targetBoardManager.sunsetZero;
                }
                else if (inGameManager.stage == inGameManager.saveData.stageList[2] || inGameManager.stage == inGameManager.saveData.stageList[4])
                {
                    targetBoardManager.gameObject.GetComponent<Image>().sprite = targetBoardManager.nightZero;
                }
            }

            if (inGameManager.orderOfShot == 10 && timer >= timeLimit)
            {
                timer = 0;
                timeBar.GetComponent<Image>().fillAmount = 1;
                scoreText = Instantiate(textPrefab, textParent.transform);
                scoreText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-295 + 71.66f * (inGameManager.orderOfShot - 1), -63, 0);
                scoreText.text = counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1].ToString();

                resultScore = Instantiate(textPrefab, textParent.transform);
                resultScore.GetComponent<RectTransform>().anchoredPosition = new Vector3(434, -63, 0);
                for (int i = 0; i < inGameManager.orderOfShot; i++)
                {
                    resultScoreOfCounter += counterScore[inGameManager.saveData.currentStageIndex, i];
                }
                resultScore.text = resultScoreOfCounter.ToString();
                resultScore.GetComponent<Text>().color = Color.black;
                yield return new WaitForSeconds(3f);
                resultPopUp.SetActive(true);
                break;
            }

            if (isPaused)
            {
                yield return null;
            }
        }
    }
    public void ShuffleList(int[,] array)
    {
        System.Random prng = new System.Random();
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 9; i++)
            {
                int randomIndex = prng.Next(i, 10);
                int temp = array[j, randomIndex];
                array[j, randomIndex] = array[j, i];
                array[j, i] = temp;
            }
        }
    }
}
