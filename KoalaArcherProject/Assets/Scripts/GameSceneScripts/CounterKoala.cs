using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterKoala : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    InGameManager inGameManager;
    SoundManager soundManager;
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
    SpriteManager spriteManager;
    Text scoreText;
    Text resultScore;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        soundManager = SoundManager.inst;
        inGameManager = FindObjectOfType<InGameManager>();
        spriteManager = FindObjectOfType<SpriteManager>();
        paramManager = inGameManager.myKoalaAnim.GetComponent<ParamManager>();
        targetBoardManager = FindObjectOfType<TargetBoardManager>();
        timeLimit = 3.8f;
        timer = 0;
        resultScoreOfCounter = 0;

        // @ 밸런스 패치 - 스코어, 순서대로 1스테이지부터 5스테이지
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
            counterImage.GetComponent<Animator>().speed = 1f;

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
                //스테이지1
                if(saveData.currentSelectedStage == saveData.stageList[0])
                {
                    spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.myKoalaDaytimeAnim.runtimeAnimatorController;
                }
                
                //스테이지4
                else if(saveData.currentSelectedStage == saveData.stageList[3])
                {
                    if(inGameManager.orderOfShot < 3)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.myKoalaDaytimeAnim.runtimeAnimatorController;
                    }
                    else if(inGameManager.orderOfShot >= 3 && inGameManager.orderOfShot < 6)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.motherKoalaDaytimeAnim.runtimeAnimatorController;
                    }
                    else if(inGameManager.orderOfShot >= 6 && inGameManager.orderOfShot < 9)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.fatherKoalaDaytimeAnim.runtimeAnimatorController;
                    }
                }

                //스테이지3
                else if(saveData.currentSelectedStage == saveData.stageList[2])
                {
                    if(inGameManager.orderOfShot < 3)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.myKoalaSunsetAnim.runtimeAnimatorController;
                    }
                    else if(inGameManager.orderOfShot >= 3 && inGameManager.orderOfShot < 6)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.motherKoalaSunsetAnim.runtimeAnimatorController;
                    }
                    else if(inGameManager.orderOfShot >= 6 && inGameManager.orderOfShot < 9)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.fatherKoalaSunsetAnim.runtimeAnimatorController;
                    }
                }

                //스테이지2, 스테이지5
                else if(saveData.currentSelectedStage == saveData.stageList[1] || saveData.currentSelectedStage == saveData.stageList[4])
                {
                    if(inGameManager.orderOfShot < 3)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.myKoalaNightAnim.runtimeAnimatorController;
                    }
                    else if(inGameManager.orderOfShot >= 3 && inGameManager.orderOfShot < 6)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.motherKoalaNightAnim.runtimeAnimatorController;
                    }
                    else if(inGameManager.orderOfShot >= 6 && inGameManager.orderOfShot < 9)
                    {
                        spriteManager.myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = spriteManager.fatherKoalaNightAnim.runtimeAnimatorController;
                    }
                }    

                counterImage.SetActive(false);
                //꺼져있던 나의 코알라를 게임씬에서 다시 켜준다.
                inGameManager.myKoalaAnim.SetActive(true);
                paramManager.StartCoroutine(paramManager.MyKoalaAnim());

                timer = 0;
                timeBar.GetComponent<Image>().fillAmount = 1;
                scoreText = Instantiate(textPrefab, textParent.transform);
                scoreText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-295 + 71.66f * (inGameManager.orderOfShot - 1), -63, 0);
                scoreText.text = counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1].ToString();

                if (inGameManager.stage == saveData.stageList[0])
                {
                    targetBoardManager.gameObject.GetComponent<Image>().sprite = targetBoardManager.daytimeZero;
                }
                else if (inGameManager.stage == saveData.stageList[2])
                {
                    targetBoardManager.gameObject.GetComponent<Image>().sprite = targetBoardManager.sunsetZero;
                }
                else if (inGameManager.stage == saveData.stageList[1])
                {
                    targetBoardManager.gameObject.GetComponent<Image>().sprite = targetBoardManager.nightZero;
                }
                else if (inGameManager.stage == saveData.stageList[3])
                {
                    targetBoardManager.gameObject.GetComponent<Image>().sprite = targetBoardManager.daytimeZero;
                }
                else if (inGameManager.stage == saveData.stageList[4])
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

                soundManager.bgmSource.Stop();
                soundManager.GameEndEffectPlay();

                yield return new WaitForSeconds(4.5f);

                resultPopUp.SetActive(true);
                break;
            }

            while (isPaused)
            {
                yield return null;
                counterImage.GetComponent<Animator>().speed = 0;
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
