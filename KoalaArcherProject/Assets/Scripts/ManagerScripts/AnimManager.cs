using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public InGameManager inGameManager;
    // Start is called before the first frame update
    void Start()
    {
        //inGameManager = FindObjectOfType<InGameManager>();
    }

    public void AngleAimingAnim()
    {
        inGameManager.StopAllCoroutines();
        inGameManager.StartCoroutine(inGameManager.PowerGaugeCoroutine());
        inGameManager.angleBarObj.SetActive(false);
        inGameManager.powerBarObj.SetActive(true);
        inGameManager.isPaused = false;
        gameObject.SetActive(false);
    }

    public void PowerGaugeAnim()
    {
        inGameManager.isPaused = false;
        inGameManager.powerBarObj.SetActive(false);
        gameObject.SetActive(false);
    }

    public void PauseCoroutine()
    {
        inGameManager.isPaused = true;
    }
}
