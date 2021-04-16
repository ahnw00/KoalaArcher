using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPanelScript : MonoBehaviour
{
    public InGameManager inGameManager;

    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void touchFunction()
    {
        if(inGameManager.isOnAmingCoroutine)
        {
            inGameManager.StopAllCoroutines(); // 작동안함
            inGameManager.isOnAmingCoroutine = false;
            float angleBarPosX = inGameManager.angleBar.GetComponent<RectTransform>().anchoredPosition.x;

            if(angleBarPosX >= -60 && angleBarPosX < 60)
            {
                inGameManager.currentAmingScore = 2;
                for(int i=0; i < 10; i++)
                {
                    if (inGameManager.amingScoreList[i] == null)
                        inGameManager.amingScoreList.Add(inGameManager.currentAmingScore);
                }
            }
            else if(angleBarPosX >= 60 && angleBarPosX < 180 && angleBarPosX >= -180 && angleBarPosX < -60)
            {
                inGameManager.currentAmingScore = 1;
                for (int i = 0; i < 10; i++)
                {
                    if (inGameManager.amingScoreList[i] == null)
                        inGameManager.amingScoreList.Add(inGameManager.currentAmingScore);
                }
            }
            else if(angleBarPosX >= 180 && angleBarPosX < 300 && angleBarPosX >= -300 && angleBarPosX < -180)
            {
                inGameManager.currentAmingScore = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (inGameManager.amingScoreList[i] == null)
                        inGameManager.amingScoreList.Add(inGameManager.currentAmingScore);
                }
            }
            

            StartCoroutine(inGameManager.PowerGaugeCoroutine());
        }

        else if(inGameManager.isOnPowerGaugeCoroutine)
        {
            inGameManager.powerGaugeBar.GetComponent<Image>().fillAmount += 0.05f;
        }
    }
}
