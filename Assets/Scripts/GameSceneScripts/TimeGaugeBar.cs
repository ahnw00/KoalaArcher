using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGaugeBar : MonoBehaviour
{
    public InGameManager inGameManager;
    public GameObject timeBar;

    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
        StartCoroutine(TimeBarCoroutine());
    }

    IEnumerator TimeBarCoroutine()
    {
        while(true)
        {
            yield return null;

            //타임바의 게이지가 1에서부터 0까지로 줄어들도록
            timeBar.GetComponent<Image>().fillAmount = 1 - (inGameManager.timer / inGameManager.stage.timeLimit);

            //만약 10번 다 쏘면 게이지도 멈춤
            if(inGameManager.orderOfShot == 10)
            {
                break;
            }
        }
    }
}
