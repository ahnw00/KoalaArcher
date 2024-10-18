using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainBtn : MonoBehaviour
{
    SoundManager soundManager;
    public void backToMainScene()
    {
        soundManager = SoundManager.inst;
        soundManager.MainBGMPlay();
        soundManager.ButtonEffectPlay();
        SceneLoadManager.instance.LoadScene("MainScene");
    }
}