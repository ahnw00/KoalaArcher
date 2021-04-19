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
        //각도 조준하는 중일때 터치를 받으면 일어나는 일들
        if(inGameManager.isOnAmingCoroutine)
        {
            inGameManager.StopAllCoroutines();
            inGameManager.isOnAmingCoroutine = false;
            float angleBarEulerZ = inGameManager.angleBar.GetComponent<RectTransform>().eulerAngles.z;

            if(angleBarEulerZ >= 170.9 && angleBarEulerZ < 190.4)
            {
                inGameManager.currentAmingScore = 2;
                inGameManager.scoreList[inGameManager.orderOfShot] += inGameManager.currentAmingScore * 4;
            }
            else if((angleBarEulerZ >= 190.4 && angleBarEulerZ < 215.5) || (angleBarEulerZ >= 145.1 && angleBarEulerZ < 170.9))
            {
                inGameManager.currentAmingScore = 1;
                inGameManager.scoreList[inGameManager.orderOfShot] += inGameManager.currentAmingScore * 4;
            }
            else if((angleBarEulerZ >= 215.5 && angleBarEulerZ < 253.5) || (angleBarEulerZ >= 102.6 && angleBarEulerZ < 145.1))
            {
                inGameManager.currentAmingScore = 0;
                inGameManager.scoreList[inGameManager.orderOfShot] += inGameManager.currentAmingScore * 4;
            }
            
            inGameManager.isOnAmingCoroutine = false;
            StartCoroutine(inGameManager.PowerGaugeCoroutine());
        }

        //파워 게이지 코루틴이 돌아가는 중에 터치를 받으면 일어나는 일
        else if(inGameManager.isOnPowerGaugeCoroutine)
        {
            inGameManager.powerGaugeBar.GetComponent<Image>().fillAmount += 0.05f;
        }
    }
}
