using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePausePopUp : MonoBehaviour
{
    GameManager gameManager;
    InGameManager inGameManager;
    public GameObject PausePopUp;

    void Start()
    {
        gameManager = GameManager.singleTon;
        inGameManager = FindObjectOfType<InGameManager>();
    }

    public void onClickSettingBtn()
    {
        inGameManager.isPaused = true;
        PausePopUp.SetActive(true);
    }

    public void onClickCloseBtn()
    {
        inGameManager.isPaused = false;
        PausePopUp.SetActive(false);
        gameManager.Save();
    }
}
