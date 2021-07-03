using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;

    public AudioSource bgmSource;
    public AudioSource effectSource;
    public AudioSource buttonSource;
    public AudioSource resultSoundSource;

    public AudioClip mainBGM;

    public AudioClip buttonClip;

    public AudioClip missEffect;
    public AudioClip goodEffect;
    public AudioClip perfectEffect;

    public AudioClip pullingEffect;
    public AudioClip fireEffect;

    // Start is called before the first frame update
    void Start()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
            return;
        }
        
        bgmSource.clip = mainBGM;
        bgmSource.volume = GameManager.singleTon.saveData.volumeOfBgm;

        buttonSource.clip = buttonClip;
        buttonSource.volume = GameManager.singleTon.saveData.volumeOfEffect;
        effectSource.volume = GameManager.singleTon.saveData.volumeOfEffect;
        resultSoundSource.volume = GameManager.singleTon.saveData.volumeOfEffect;

        bgmSource.Play();
    }

    public void ButtonEffectPlay()
    {
        buttonSource.Play();
    }

    public void PullingEffectPlay()
    {
        if(effectSource.clip == pullingEffect)
        {
            return;
        }
        effectSource.clip = pullingEffect;
        effectSource.Play();
    }

    public void FireEffectPlay()
    {
        if(effectSource.clip == fireEffect)
        {
            return;
        }
        effectSource.clip = fireEffect;
        effectSource.Play();
    }
}
