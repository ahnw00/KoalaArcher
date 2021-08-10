using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBtnPopUp : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    SoundManager soundManager;
    public GameObject popUp; 

 

    public void OpenPopUp()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        soundManager = SoundManager.inst;

        if(!saveData.isFirstTimeOfPlay)
        {
            soundManager.ButtonEffectPlay();
            popUp.SetActive(true);
        }

        else
        {
            soundManager.ButtonEffectPlay();
            soundManager.StageBGMPlay();
            SceneLoadManager.instance.LoadScene("CutScene");
        }
    }
}
