using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider effectSlider;
    public SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Update()
    {
        //value값을 계속 맞춰주는 작업
        //여기서 bgm, soundeffect를 모두 관리

        soundManager.bgmSource.volume = bgmSlider.value;
        soundManager.effectSource.volume = effectSlider.value;
    }
}
