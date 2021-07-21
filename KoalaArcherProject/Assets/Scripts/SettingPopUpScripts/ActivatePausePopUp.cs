using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePausePopUp : MonoBehaviour
{
    GameManager gameManager;
    InGameManager inGameManager;
    CounterKoala counterKoala;
    SoundManager soundManager;
    public GameObject PausePopUp;

    void Start()
    {
        gameManager = GameManager.singleTon;
        soundManager = SoundManager.inst;
        inGameManager = FindObjectOfType<InGameManager>();
        counterKoala = FindObjectOfType<CounterKoala>();
    }

    public void onClickSettingBtn()
    {
        inGameManager.isPaused = true;
        counterKoala.isPaused = true;
        PausePopUp.SetActive(true);
        soundManager.ButtonEffectPlay();
        if(inGameManager.numberOfClicked == 1)
        {
            inGameManager.numberOfClicked -= 1;
        }
        
    }

    public void onClickCloseBtn()
    {
        soundManager.ButtonEffectPlay();
        inGameManager.isPaused = false;
        counterKoala.isPaused = false;
        PausePopUp.SetActive(false);
        gameManager.Save();
    }
}
