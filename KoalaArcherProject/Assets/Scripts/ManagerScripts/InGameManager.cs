using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    public StageClass stage;
    public GameObject angleBar;
    public GameObject powerGaugeBar;
    public bool isOnAmingCoroutine;
    public bool isOnPowerGaugeCoroutine;
    public int currentAmingScore;
    public int currentPowerScore;
    public List<int> scoreList;
    public int orderOfShot;
    public bool whileShooting; //패널을 터치할때 슈팅하고 있을때만 터치할 수 있도록
    public float timer;
    //public GameObject textPrefab;
    //IEnumerator angleCoroutine;
    //IEnumerator powerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        stage = saveData.currentSelectedStage;
        scoreList = new List<int>();
        orderOfShot = 0;
        timer = 0;
        for(int i = 0; i < 10; i++)
        {
            scoreList.Add(0);
        }

        StartCoroutine(AngleAmingCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer);
    }


    //각도 조준선 왔다리 갔다리 하는 것을 AngleAmingCoroutine에서 구현
    public IEnumerator AngleAmingCoroutine()
    {
        float leftOrRight = 1;

        while(true)
        {
            yield return null;
            isOnAmingCoroutine = true;
            whileShooting = true;
            Vector3 barPosition = angleBar.GetComponent<RectTransform>().eulerAngles;

            if(barPosition.z < 102.6f)
            {
                leftOrRight = 1;
            }
            else if(barPosition.z > 253.5f)
            {
                leftOrRight = -1;
            }
            angleBar.transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * stage.aimSpeed * leftOrRight);
            
            //만약 제한 시간이 지날 경우 코루틴이 끝나도록
            timer += Time.deltaTime;  
            if(timer >= stage.timeLimit)
            {
                isOnAmingCoroutine = false;
                orderOfShot++;
                StopAllCoroutines();
            }       
        }        
    }


    //파워 게이지 점차 줄어드는 것을 PowerGaugeCoroutine에서 구현
    public IEnumerator PowerGaugeCoroutine()
    {
        while(true)
        {
            yield return null;
            isOnPowerGaugeCoroutine = true;
            float powerGaugeFillAmount = powerGaugeBar.GetComponent<Image>().fillAmount;

            powerGaugeBar.GetComponent<Image>().fillAmount = Mathf.Lerp(powerGaugeBar.GetComponent<Image>().fillAmount, 0, Time.deltaTime * stage.powerGaugeSpeed); 


            //제한 시간이 지나면 코루틴을 종료하고 점수를 반환한다.
            timer += Time.deltaTime;
            if(timer >= stage.timeLimit)
            {
                isOnPowerGaugeCoroutine = false;
                orderOfShot++;
                if(powerGaugeFillAmount > 0.75)
                {
                    currentPowerScore = 1;
                    scoreList[orderOfShot] += currentPowerScore * 2;

                    switch(scoreList[orderOfShot])
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
                else if(powerGaugeFillAmount <= 0.75)
                {
                    currentPowerScore = 0;
                    scoreList[orderOfShot] += currentPowerScore * 2;

                    switch(scoreList[orderOfShot])
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
                angleBar.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 180);
                powerGaugeBar.GetComponent<Image>().fillAmount = 1;
                yield return new WaitForSeconds(3f);

                if(orderOfShot != 10)
                {
                    StartCoroutine(AngleAmingCoroutine());
                }
                
                break;
            }
        }
    }
}
