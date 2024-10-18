using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStageBtn : MonoBehaviour
{
    SoundManager soundManager;
    public void backToStageScene()
    {
        soundManager = SoundManager.inst;
        soundManager.bgmSource.clip = soundManager.stageBGM;
        soundManager.bgmSource.Play();
        soundManager.ButtonEffectPlay();
        SceneLoadManager.instance.LoadScene("StageScene");
    }
}
