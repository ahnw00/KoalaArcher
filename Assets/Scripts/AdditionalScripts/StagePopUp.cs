using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePopUp : MonoBehaviour
{
    public GameObject popUp;
    SoundManager soundManager;
    GameManager gameManager;

    public void OpenPopUp()
    {
        soundManager = SoundManager.inst;
        soundManager.SecondButtonPlay();
        popUp.SetActive(true);
    }

    public void ClosePopUp()
    {
        soundManager = SoundManager.inst;
        soundManager.SecondButtonPlay();

        gameManager = GameManager.singleTon;
        gameManager.Save();

        popUp.SetActive(false);
    }
}
