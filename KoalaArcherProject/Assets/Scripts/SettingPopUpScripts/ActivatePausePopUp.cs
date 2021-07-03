using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePausePopUp : MonoBehaviour
{
    GameManager gameManager;
    InGameManager inGameManager;
    CounterKoala counterKoala;
    public GameObject PausePopUp;

    void Start()
    {
        gameManager = GameManager.singleTon;
        inGameManager = FindObjectOfType<InGameManager>();
        counterKoala = FindObjectOfType<CounterKoala>();
    }

    public void onClickSettingBtn()
    {
        inGameManager.isPaused = true;
        counterKoala.isPaused = true;
        PausePopUp.SetActive(true);
    }

    public void onClickCloseBtn()
    {
        inGameManager.isPaused = false;
        counterKoala.isPaused = false;
        PausePopUp.SetActive(false);
        gameManager.Save();
    }
}
