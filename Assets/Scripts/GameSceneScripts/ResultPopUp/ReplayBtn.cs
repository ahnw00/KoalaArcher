using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayBtn : MonoBehaviour
{   
    SoundManager soundManager;
    public void Replay()
    {
        soundManager = SoundManager.inst;
        soundManager.SecondButtonPlay();
        SceneLoadManager.instance.LoadScene("GameScene");
    }
}
