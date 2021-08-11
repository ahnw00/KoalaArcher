using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamManager : MonoBehaviour
{
    InGameManager inGameManager;
    SoundManager soundManager;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
        soundManager = SoundManager.inst;
        animator = GetComponent<Animator>();
        StartCoroutine(MyKoalaAnim());
    }

    public IEnumerator MyKoalaAnim()
    {
        while(true)
        {
            yield return null;

            if(inGameManager.isOnPowerGaugeCoroutine)
            {
                animator.SetTrigger("readyToGauge");
                soundManager.PullingEffectPlay();
            }
            if(inGameManager.timer >= inGameManager.stage.timeLimit - 0.2f)
            {
                animator.SetTrigger("gaugeToShoot");
                soundManager.FireEffectPlay();
            }
            if(inGameManager.numberOfClicked == 1)
            {
                animator.SetTrigger("raiseArchery");
            }
        }
    }
}
