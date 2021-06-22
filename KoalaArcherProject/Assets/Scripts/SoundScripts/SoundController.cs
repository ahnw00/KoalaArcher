using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    GameManager gameManager;
    public SaveDataClass saveData;
    public SoundManager soundManager;
    public Slider bgmSlider;
    public Slider effectSlider;

    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;

        soundManager = FindObjectOfType<SoundManager>();

        bgmSlider.value = saveData.volumeOfBgm;
        effectSlider.value = saveData.volumeOfEffect;
    }

    public void setBgmVolume()
    {
        soundManager.bgmSource.volume = bgmSlider.value;
        saveData.volumeOfBgm = bgmSlider.value;
    }

    public void setEffectVolume()
    {
        soundManager.effectSource.volume = effectSlider.value;
        soundManager.buttonSource.volume = effectSlider.value;
        saveData.volumeOfEffect = effectSlider.value;
    }
}
