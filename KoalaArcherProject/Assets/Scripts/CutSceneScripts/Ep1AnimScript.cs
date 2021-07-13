using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ep1AnimScript : MonoBehaviour
{
    GameManager gameManager;
    public SaveDataClass saveData;
    public Animator anim;

    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        anim = GetComponent<Animator>();
        if (saveData.currentStageIndex == 0)
        {
            anim.enabled = true;
        }
        else
        {
            anim.enabled = false;
        }
    }
}
