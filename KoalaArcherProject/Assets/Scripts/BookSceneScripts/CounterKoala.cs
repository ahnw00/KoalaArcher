using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterKoala : MonoBehaviour
{
    public InGameManager inGameManager;
    public GameObject timeBar;
    public GameObject counterKoala;
    public GameObject myKoala;
    public GameObject aimingObj;
    public GameObject powerObj;
    public float timer;
    public float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
        timeLimit = 3f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CounterTimeBarCoroutine()
    {
        while(true)
        {
            yield return null;
            timer += Time.deltaTime;

            if(!inGameManager.whileShooting)
            {
                myKoala.SetActive(false);
                aimingObj.SetActive(false);
                powerObj.SetActive(false);
                counterKoala.SetActive(true);

                timeBar.GetComponent<Image>().fillAmount = 1 - (timer / timeLimit);
            }

            else if(inGameManager.whileShooting)
            {
                myKoala.SetActive(true);
                aimingObj.SetActive(true);
                powerObj.SetActive(true);
                counterKoala.SetActive(false);
                timer = 0;
                break;
            }
        }
    }
}
