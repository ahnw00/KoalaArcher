using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RivalUI : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;

    //라이벌 코알라 오브젝트들
    public GameObject rivalKoalaName;
    public GameObject rivalFace;

    //라이벌 코알라 얼굴 스프라이트들
    public Sprite farmerFace;
    public Sprite babyFace;
    public Sprite hunterFace;
    public Sprite granfaFace;
    public Sprite sleepyFace;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;

        if(saveData.currentStageIndex == 0)
        {
            rivalKoalaName.GetComponent<Text>().text = "농부";
            rivalKoalaName.GetComponent<Text>().fontSize = 50;

            rivalFace.GetComponent<Image>().sprite = farmerFace;
        }
        else if(saveData.currentStageIndex == 1)
        {
            rivalKoalaName.GetComponent<Text>().text = "애기";
            rivalKoalaName.GetComponent<Text>().fontSize = 50;

            rivalFace.GetComponent<Image>().sprite = babyFace;
        }
        else if(saveData.currentStageIndex == 2)
        {
            rivalKoalaName.GetComponent<Text>().text = "사냥꾼";
            rivalKoalaName.GetComponent<Text>().fontSize = 40;

            rivalFace.GetComponent<Image>().sprite = hunterFace;
        }
        else if(saveData.currentStageIndex == 3)
        {
            rivalKoalaName.GetComponent<Text>().text = "잠꾸러기";
            rivalKoalaName.GetComponent<Text>().fontSize = 35;

            rivalFace.GetComponent<Image>().sprite = sleepyFace;
        }
        else if(saveData.currentStageIndex == 4)
        {
            rivalKoalaName.GetComponent<Text>().text = "할아버지";
            rivalKoalaName.GetComponent<Text>().fontSize = 35;

            rivalFace.GetComponent<Image>().sprite = granfaFace;
        }
    }
}
