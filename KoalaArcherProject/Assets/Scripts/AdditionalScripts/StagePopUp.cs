using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePopUp : MonoBehaviour
{
    public GameObject popUp;
    SoundManager soundManager;

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
        popUp.SetActive(false);
    }
}
