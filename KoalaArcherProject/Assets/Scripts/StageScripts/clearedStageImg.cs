using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clearedStageImg : MonoBehaviour
{
    //sprite 배열로 5개 가져오기
    //스테이지 인덱스 가져와서 해당하는 sprite를 img object에 삽입
    public List<Sprite> clearedImgList;

    void Start()
    {
        int idx = GameManager.singleTon.saveData.indexOfStageCompleted;

        gameObject.GetComponent<Image>().sprite = clearedImgList[idx];
    }
}