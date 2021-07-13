using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpCutSceneImage : MonoBehaviour
{
    public List<Image> Images;

    public List<Sprite> ImgList1;
    public List<Sprite> ImgList2;
    public List<Sprite> ImgList3;
    public List<Sprite> ImgList4;
    public List<Sprite> ImgList5;
    public List<Sprite> ImgList6;
    public List<Sprite> ImgList7;

    GameManager gameManager;
    public SaveDataClass saveData;
    int currentStageNum;

    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        currentStageNum = saveData.currentStageIndex + 1;
        SetCutSceneImage(currentStageNum);
    }

    public void SetCutSceneImage(int stageNum)
    {
        Images[0].sprite = ImgList1[stageNum - 1];
        Images[1].sprite = ImgList2[stageNum - 1];
        Images[2].sprite = ImgList3[stageNum - 1];
        Images[3].sprite = ImgList4[stageNum - 1];
        Images[4].sprite = ImgList5[stageNum - 1];
        Images[5].sprite = ImgList6[stageNum - 1];
        Images[6].sprite = ImgList7[stageNum - 1];
    }
}
