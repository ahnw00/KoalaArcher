using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotResultEffect : MonoBehaviour
{
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.inst;
    }

    public void PerfectSoundEffect()
    {
        soundManager.resultSoundSource.clip = soundManager.perfectEffect;
        soundManager.resultSoundSource.Play();
    }

    public void GoodSoundEffect()
    {
        soundManager.resultSoundSource.clip = soundManager.goodEffect;
        soundManager.resultSoundSource.Play();
    }

    public void MissSoundEffect()
    {
        soundManager.resultSoundSource.clip = soundManager.missEffect;
        soundManager.resultSoundSource.Play();
    }
}
