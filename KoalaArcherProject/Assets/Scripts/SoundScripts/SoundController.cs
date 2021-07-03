using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    GameManager gameManager;
    SoundManager soundManager;
    public Slider bgmSlider;
    public Slider effectSlider;

    void Start()
    {
        gameManager = GameManager.singleTon;
        soundManager = SoundManager.inst;

        bgmSlider.value = gameManager.saveData.volumeOfBgm;
        effectSlider.value = gameManager.saveData.volumeOfEffect;
    }

    public void SetBgmVolume()
    {
        soundManager.bgmSource.volume = bgmSlider.value;
        gameManager.saveData.volumeOfBgm = bgmSlider.value;
        gameManager.Save();
    }

    public void SetEffectVolume()
    {
        soundManager.effectSource.volume = effectSlider.value;
        soundManager.buttonSource.volume = effectSlider.value;
        soundManager.resultSoundSource.volume = effectSlider.value;
        gameManager.saveData.volumeOfEffect = effectSlider.value;
        gameManager.Save();
    }
}
