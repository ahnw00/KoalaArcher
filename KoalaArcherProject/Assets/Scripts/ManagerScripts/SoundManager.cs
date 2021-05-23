using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;

    public AudioSource bgmSource;
    public AudioSource effectSource;
    public AudioSource buttonSource;

    public AudioClip mainBGM;

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
        bgmSource.volume = GameManager.singleTon.saveData.volumeOfBgm; //다인 추가
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
