using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearedStageImg : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    public List<GameObject> clearedImgList;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        // 우측 상단 클리어한 스테이지 이미지 activate
        if (saveData.indexOfStageCompleted != 0)
        {
            clearedImgList[saveData.indexOfStageCompleted - 1].SetActive(false);
        }
        clearedImgList[saveData.indexOfStageCompleted].SetActive(true);
    }
}
