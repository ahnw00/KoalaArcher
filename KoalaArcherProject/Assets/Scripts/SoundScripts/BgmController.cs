using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmController : MonoBehaviour
{
    GameManager gameManager;
    SoundManager soundManager;
    public Slider bgmSlider;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        soundManager = SoundManager.inst;

        bgmSlider.value = gameManager.saveData.volumeOfBgm;
    }
    
    public void SetBgmVolume()
    {
        soundManager.bgmSource.volume = bgmSlider.value;
        gameManager.saveData.volumeOfBgm = bgmSlider.value;
        gameManager.Save();
    }
}
