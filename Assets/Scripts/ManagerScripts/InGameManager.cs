using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    GameManager gameManager;
    public SaveDataClass saveData;
    SoundManager soundManager;
    ScoreScript scoreScript;
    SpriteManager spriteManager;
    public StageClass stage;
    public GameObject angleBar;
    public GameObject powerGaugeBar;
    public GameObject perfect;
    public GameObject good;
    public GameObject miss;
    public GameObject strong;
    public GameObject weak;
    public bool isPaused;
    public bool isOnAmingCoroutine;
    public bool isOnPowerGaugeCoroutine;
    public int currentAmingScore;
    public int currentPowerScore;
    public List<int> scoreList;
    public int orderOfShot;
    public bool whileShooting; //패널을 터치할때 슈팅하고 있을때만 터치할 수 있도록
    public float timer;
    public int numberOfClicked;
    public bool isShotFinished;
    public bool isMyShot;
    public IEnumerator angleCoroutine;
    public IEnumerator powerCoroutine;
    public GameObject angleBarObj;
    public GameObject powerBarObj;
    public GameObject myKoalaAnim;
    public GameObject spectator;
    bool appearCutSwitch;

    void Awake()
    {
        CameraResolution.instance.SetResolution();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        soundManager = SoundManager.inst;
        stage = saveData.currentSelectedStage;
        spriteManager = FindObjectOfType<SpriteManager>();
        scoreScript = FindObjectOfType<ScoreScript>();
        scoreList = new List<int>();
        isPaused = false;
        appearCutSwitch = true;
        numberOfClicked = 0;
        orderOfShot = 0;
        timer = 0;
        for (int i = 0; i < 10; i++)
        {
            scoreList.Add(0);
        }

        angleCoroutine = AngleAmingCoroutine();
        powerCoroutine = PowerGaugeCoroutine();

        StartCoroutine(angleCoroutine);
    }

    //각도 조준선 왔다리 갔다리 하는 것을 AngleAmingCoroutine에서 구현
    public IEnumerator AngleAmingCoroutine()
    {
        float leftOrRight = 1;

        while (true)
        {
            yield return null;
            myKoalaAnim.GetComponent<Animator>().speed = 1f;

            isOnAmingCoroutine = true;
            whileShooting = true;
            Vector3 barPosition = angleBar.GetComponent<RectTransform>().localEulerAngles;

            if (numberOfClicked == 0)
            {
                angleBarObj.SetActive(true);
                if(orderOfShot == 0 && appearCutSwitch)
                {
                    isPaused = true;
                    spriteManager.appearCutObj.transform.GetChild(1).GetComponent<Image>().sprite = spriteManager.koalaAppearCut;
                    spriteManager.appearCutObj.SetActive(true);
                    soundManager.AppearEffectPlay();

                    spectator.GetComponent<Animator>().SetTrigger("Cheering");
                    appearCutSwitch = false;
                }
                else if(orderOfShot == 3 && !appearCutSwitch && saveData.currentSelectedStage != saveData.stageList[0])
                {
                    isPaused = true;
                    spriteManager.appearCutObj.transform.GetChild(1).GetComponent<Image>().sprite = spriteManager.momAppearCut;
                    spriteManager.appearCutObj.SetActive(true);
                    soundManager.AppearEffectPlay();

                    spectator.GetComponent<Animator>().SetTrigger("Cheering");
                    appearCutSwitch = true;
                }
                else if(orderOfShot == 6 && appearCutSwitch && saveData.currentSelectedStage != saveData.stageList[0])
                {
                    isPaused = true;
                    spriteManager.appearCutObj.transform.GetChild(1).GetComponent<Image>().sprite = spriteManager.dadAppearCut;
                    spriteManager.appearCutObj.SetActive(true);
                    soundManager.AppearEffectPlay();

                    spectator.GetComponent<Animator>().SetTrigger("Cheering");
                    appearCutSwitch = false;
                }
            }

            //한번 누르면 클릭 횟수 1증가
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                numberOfClicked++;
            }

            //클릭 횟수가 한번 이상일 경우 에이밍바를 왔다리 갔다리 해주고 타이머 흐르도록..
            if (numberOfClicked != 0)
            {
                timer += Time.deltaTime;
                if (barPosition.z < 93f)
                {
                    leftOrRight = 1;
                }
                else if (barPosition.z > 260.2f)
                {
                    leftOrRight = -1;
                }
                angleBar.transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * stage.aimSpeed * leftOrRight);
            }

            //만약 아무것도 안누른채 제한 시간이 지날 경우 파워게이지 코루틴으로 넘어가도록. 그 후엔 파워게이지의 if문에 걸려 바로 점수 반환이 됨. 
            if (timer >= stage.timeLimit)
            {
                isOnAmingCoroutine = false;
                angleBarObj.SetActive(false);
                StartCoroutine(PowerGaugeCoroutine());
                break;
            }

            while (isPaused)
            {
                yield return null;
                myKoalaAnim.GetComponent<Animator>().speed = 0f;
            }
        }
    }


    //파워 게이지 점차 줄어드는 것을 PowerGaugeCoroutine에서 구현
    public IEnumerator PowerGaugeCoroutine()
    {
        while (true)
        {
            yield return null;
            myKoalaAnim.GetComponent<Animator>().speed = 1f;

            //isPaused = false;  < 이게 꼭 필요한건가요?
            numberOfClicked = 0;
            isOnPowerGaugeCoroutine = true;
            float powerGaugeFillAmount = powerGaugeBar.GetComponent<Image>().fillAmount;

            powerGaugeBar.GetComponent<Image>().fillAmount = Mathf.Lerp(powerGaugeFillAmount, 0, Time.deltaTime * stage.powerGaugeSpeed);

            //제한 시간이 지나면 코루틴을 종료하고 점수를 반환한다.
            timer += Time.deltaTime;
            if (timer >= stage.timeLimit)
            {
                isOnPowerGaugeCoroutine = false;

                if (powerGaugeFillAmount > 0.75)
                {
                    currentPowerScore = 1;
                    scoreList[orderOfShot] += currentPowerScore * 2;
                    strong.SetActive(true);

                    switch (scoreList[orderOfShot])
                    {
                        case 8:
                            scoreList[orderOfShot] = 9;
                            break;

                        case 6:
                            scoreList[orderOfShot] = 8;
                            break;

                        case 4:
                            scoreList[orderOfShot] = 7;
                            break;

                        case 2:
                            scoreList[orderOfShot] = 6;
                            break;
                    }
                }
                else if (powerGaugeFillAmount <= 0.75)
                {
                    currentPowerScore = 0;
                    scoreList[orderOfShot] += currentPowerScore * 2;
                    weak.SetActive(true);

                    switch (scoreList[orderOfShot])
                    {
                        case 8:
                            scoreList[orderOfShot] = 9;
                            break;

                        case 6:
                            scoreList[orderOfShot] = 8;
                            break;

                        case 4:
                            scoreList[orderOfShot] = 7;
                            break;

                        case 2:
                            scoreList[orderOfShot] = 6;
                            break;
                    }
                }

                whileShooting = false;
                timer = 0;
                numberOfClicked = 0;
                angleBar.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -99.8f);
                powerGaugeBar.GetComponent<Image>().fillAmount = 0;

                
                //10번째 슈팅이 아닐 경우, 3초 뒤에 다음 코루틴을 실행시킨다.
                if (orderOfShot < 9)
                {
                    orderOfShot++;
                    scoreScript.InstantiationOfScoreText();
                }
                //10번째 슈팅일 경우, 더 이상 코루틴을 실행하지 않는다.
                else if (orderOfShot == 9)
                {
                    orderOfShot++;
                    scoreScript.InstantiationOfScoreText();
                    scoreScript.ShowResultScore();
                }
                
                break;
            }

            while (isPaused) //일시정지 위해서 추가
            {
                yield return null;
                myKoalaAnim.GetComponent<Animator>().speed = 0f;
            }
        }
    }
}
