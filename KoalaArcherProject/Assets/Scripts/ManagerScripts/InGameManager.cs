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
    public List<int> amingScoreList;
    public List<int> powerScoreList;

    public GameObject textPrefab;
    //IEnumerator angleCoroutine;
    //IEnumerator powerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        stage = saveData.currentSelectedStage;
        scoreList = new List<int>();
        amingScoreList = new List<int>();
        powerScoreList = new List<int>();

        StartCoroutine(AngleAmingCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AngleAmingCoroutine()
    {
        float leftOrRight = 1;
        float timer = 0;

        while(true)
        {
            yield return null;
            isOnAmingCoroutine = true;
            Vector2 barPosition = angleBar.GetComponent<RectTransform>().anchoredPosition;


            if(barPosition.x > 287)
            {
                leftOrRight = -1;
            }
            else if(barPosition.x < -287)
            {
                leftOrRight = 1;
            }
            angleBar.transform.Translate(Vector2.right * Time.deltaTime * stage.aimSpeed * leftOrRight);
            

            timer += Time.deltaTime;
            if(timer >= 5)
            {             
                isOnAmingCoroutine = false;  
                break;
            }            
        }        
    }

    public IEnumerator PowerGaugeCoroutine()
    {
        float timer = 0;
        //float isUnderBottom = 1;

        while(true)
        {
            yield return null;
            isOnPowerGaugeCoroutine = true;
            Vector2 powerGaugePosition = powerGaugeBar.GetComponent<RectTransform>().anchoredPosition;


            /*if(powerGaugePosition.y < -852)
            {
                isUnderBottom = 0;
            }
            else if(powerGaugePosition.y >= -852)
            {
                isUnderBottom = 1;
            }*/
            //powerGaugeBar.transform.Translate(Vector2.down * Time.deltaTime * stage.powerGaugeSpeed * isUnderBottom);
            powerGaugeBar.GetComponent<Image>().fillAmount = Mathf.Lerp(powerGaugeBar.GetComponent<Image>().fillAmount,0, Time.deltaTime * stage.powerGaugeSpeed); 
            //Time.deltaTime * stage.powerGaugeSpeed * isUnderBottom; 


            timer += Time.deltaTime;
            if(timer >= 5)
            {
                isOnPowerGaugeCoroutine = false;
                if(powerGaugeBar.GetComponent<Image>().fillAmount > 0.75)
                {
                    currentPowerScore = 1;
                    for (int i = 0; i < 10; i++)
                    {
                        if (powerScoreList[i] == null)
                            powerScoreList.Add(currentPowerScore);
                    }
                }
                else if(powerGaugeBar.GetComponent<Image>().fillAmount <= 0.75)
                {
                    currentPowerScore = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        if (powerScoreList[i] == null)
                            powerScoreList.Add(currentPowerScore);
                    }
                }

                

                break;
            }
        }
    }
}
