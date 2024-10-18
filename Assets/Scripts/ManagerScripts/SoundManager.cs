using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;

    //사운드 소스
    public AudioSource bgmSource;
    public AudioSource effectSource;
    public AudioSource buttonSource;
    public AudioSource resultSoundSource;

    //배경음악 오디오 클립
    public AudioClip mainBGM;
    public AudioClip stageBGM;
    public AudioClip inGameBGM;

    //버튼 오디오 클립
    public AudioClip buttonClip;
    public AudioClip secondButtonClip;

    //샷 이펙트 오디오 클립
    public AudioClip missEffect;
    public AudioClip goodEffect;
    public AudioClip perfectEffect;

    //활 이펙트 오디오 클립
    public AudioClip pullingEffect;
    public AudioClip fireEffect;

    //코알라 등장 이펙트 오디오 클립 *
    public AudioClip ourTeamAppearEffect;
    public AudioClip rivalTeamAppearEffect;

    //게임 끝, 결과 오디오 클립
    public AudioClip gameEndEffect;
    public AudioClip gameWinEffect;
    public AudioClip gameLoseEffect;

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
        buttonSource.clip = buttonClip;
        buttonSource.Play();
    }

    public void SecondButtonPlay()
    {
        buttonSource.clip = secondButtonClip;
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

    public void StageBGMPlay()
    {
        bgmSource.clip = stageBGM;
        bgmSource.Play();
    }

    public void MainBGMPlay()
    {
        bgmSource.clip = mainBGM;
        bgmSource.Play();
    }

    public void InGameBGMPlay()
    {
        bgmSource.clip = inGameBGM;
        bgmSource.Play();
    }

    public void AppearEffectPlay()
    {
        effectSource.clip = ourTeamAppearEffect;
        effectSource.Play();
    }

    public void GameEndEffectPlay()
    {
        effectSource.clip = gameEndEffect;
        effectSource.Play();
    }

    public void GameWinEffectPlay()
    {
        effectSource.clip = gameWinEffect;
        effectSource.Play();
    }

    public void GameLoseEffectPlay()
    {
        effectSource.clip = gameLoseEffect;
        effectSource.Play();
    }
}