using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider effectSlider;
    public AudioSource bgmSource;
    public AudioSource effectSource;

    void Start()
    {
        bgmSource = SoundManager.inst.bgmSource;
        effectSource = SoundManager.inst.effectSource;
    }
    void Update()
    {
        //value값을 계속 맞춰주는 작업
        //여기서 bgm, soundeffect를 모두 관리

        bgmSource = bgmSlider.value;
        effectSource = effectSlider.value;
    }
}
