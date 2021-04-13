using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    StageClass stage;
    public GameObject angleBar;
    public GameObject powerGauge;
    //IEnumerator angleCoroutine;
    //IEnumerator powerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        stage = saveData.currentStage;

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
                break;
            }            
        }        
    }

    IEnumerator PowerGaugeCoroutine()
    {
        yield return null;
    }
}
