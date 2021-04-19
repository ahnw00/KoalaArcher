using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    StageClass stage;
    public GameObject angleBar;
    public GameObject powerGaugeBar;
    public bool isOnAmingCoroutine;
    public bool isOnPowerGaugeCoroutine;
    public int currentAmingScore;
    public int currentPowerScore;
    public List<int> scoreList;
    public int orderOfShot;
    public bool whileShooting;
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

    IEnumerator AngleAmingCoroutine()
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

            Debug.Log(barPosition.z);
            
            timer += Time.deltaTime;  
            if(timer >= stage.timeLimit)
            {
                isOnAmingCoroutine = false;
            }       
        }        
    }

    public IEnumerator PowerGaugeCoroutine()
    {
        while(true)
        {
            yield return null;
            isOnPowerGaugeCoroutine = true;
            Vector2 powerGaugePosition = powerGaugeBar.GetComponent<RectTransform>().anchoredPosition;

            powerGaugeBar.GetComponent<Image>().fillAmount = Mathf.Lerp(powerGaugeBar.GetComponent<Image>().fillAmount,0, Time.deltaTime * stage.powerGaugeSpeed); 

            timer += Time.deltaTime;
            if(timer >= stage.timeLimit)
            {
                isOnPowerGaugeCoroutine = false;
                if(powerGaugeBar.GetComponent<Image>().fillAmount > 0.75)
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
                else if(powerGaugeBar.GetComponent<Image>().fillAmount <= 0.75)
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
                break;
            }
        }
    }
}
