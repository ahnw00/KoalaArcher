using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterTimeGaugeBar : MonoBehaviour
{
    public InGameManager inGameManager;
    public GameObject timeBar;
    public GameObject counterKoala;
    public GameObject myKoala;
    public GameObject aimingObj;
    public GameObject powerObj;

    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
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

            if(!inGameManager.whileShooting)
            {
                myKoala.SetActive(false);
                aimingObj.SetActive(false);
                powerObj.SetActive(false);
                counterKoala.SetActive(true);
            }
        }
    }
}
