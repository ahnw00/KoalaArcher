using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterKoalaSoundEffect : MonoBehaviour
{
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.inst;
    }

    public void PullingSoundEffect()
    {
        soundManager.effectSource.clip = soundManager.pullingEffect;
        soundManager.effectSource.Play();
    }

    public void FireSoundEffect()
    {
        soundManager.effectSource.clip = soundManager.fireEffect;
        soundManager.effectSource.Play();
    }
}
