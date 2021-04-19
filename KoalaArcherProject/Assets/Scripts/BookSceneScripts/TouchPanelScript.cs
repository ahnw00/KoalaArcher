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
            float angleBarEulerZ = inGameManager.angleBar.GetComponent<RectTransform>().eulerAngles.z;

            if(angleBarEulerZ >= -60 && angleBarEulerZ < 60)
            {
                inGameManager.currentAmingScore = 2;
                inGameManager.scoreList[inGameManager.orderOfShot] += inGameManager.currentAmingScore * 4;
            }
            else if(angleBarEulerZ >= 60 && angleBarEulerZ < 180 && angleBarEulerZ >= -180 && angleBarEulerZ < -60)
            {
                inGameManager.currentAmingScore = 1;
                inGameManager.scoreList[inGameManager.orderOfShot] += inGameManager.currentAmingScore * 4;
            }
            else if(angleBarEulerZ >= 180 && angleBarEulerZ < 300 && angleBarEulerZ >= -300 && angleBarEulerZ < -180)
            {
                inGameManager.currentAmingScore = 0;
                inGameManager.scoreList[inGameManager.orderOfShot] += inGameManager.currentAmingScore * 4;
            }
            
            inGameManager.isOnAmingCoroutine = false;
            StartCoroutine(inGameManager.PowerGaugeCoroutine());
        }

        else if(inGameManager.isOnPowerGaugeCoroutine)
        {
            inGameManager.powerGaugeBar.GetComponent<Image>().fillAmount += 0.05f;
        }
    }
}
