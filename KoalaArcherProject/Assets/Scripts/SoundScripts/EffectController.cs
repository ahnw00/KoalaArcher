using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectController : MonoBehaviour
{
    GameManager gameManager;
    SoundManager soundManager;
    public Slider effectSlider;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        soundManager = SoundManager.inst;

        effectSlider.value = gameManager.saveData.volumeOfEffect;
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
