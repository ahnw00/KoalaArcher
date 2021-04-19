using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateLoadBtn : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        if (saveData.isFirstTimeOfPlay == false)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
