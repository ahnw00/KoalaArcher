using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;

    //낮 스프라이트들
    public Sprite summerDaytimeBGSprite;
    public Sprite summerDaytimeSkySprite;
    public Sprite fallDaytimeBGSprite;
    public Sprite fallDaytimeSkySprite;
    public Sprite daytimeSpectatorSprite;

    //노을 스프라이트들
    public Sprite sunsetBGSprite;
    public Sprite sunsetSkySprite;
    public Sprite sunsetSpectatorSprite;

    //밤 스프라이트들
    public Sprite summerNightBGSprite;
    public Sprite summerNightSkySprite;
    public Sprite fallNightBGSprite;
    public Sprite fallNightSkySprite;
    public Sprite nightSpectatorSprite;

    //어피어 컷 스프라이트들
    public Sprite koalaAppearCut;
    public Sprite momAppearCut;
    public Sprite dadAppearCut;

    //상대 코알라 애니메이션들
    public Animator farmerKoalaAnim;
    public Animator babyKoalaAnim;
    public Animator hunterKoalaAnim;
    public Animator sleepyKoalaAnim;
    public Animator grandfaKoalaAnim;

    //나의 코알라 애니메이션들
    public Animator myKoalaDaytimeAnim;
    public Animator myKoalaSunsetAnim;
    public Animator myKoalaNightAnim;
    public Animator motherKoalaDaytimeAnim;
    public Animator motherKoalaSunsetAnim;
    public Animator motherKoalaNightAnim;
    public Animator fatherKoalaDaytimeAnim;
    public Animator fatherKoalaSunsetAnim;
    public Animator fatherKoalaNightAnim;

    //애니메이션 배경 오브젝트들
    public GameObject cloud;
    public GameObject star;
    public GameObject sun;
    public GameObject summerDaytimeBird;
    public GameObject fallDaytimeBird;
    public GameObject sunsetBird;

    //배경 오브젝트들
    public GameObject backgroundObject;
    public GameObject skyObject;
    public GameObject spectatorObject;

    //코알라 오브젝트들
    public GameObject myKoalaObj;
    public GameObject counterKoalaObj;

    //어피어 컷 오브젝트
    public GameObject appearCutObj;

    //결과창 스테이지 표시 오브젝트
    public GameObject currentStage;

    //결과창 스테이지 표시 스프라이트
    public Sprite stage1;
    public Sprite stage2;
    public Sprite stage3;
    public Sprite stage4;
    public Sprite stage5;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;

        if(saveData.currentSelectedStage == saveData.stageList[0])
        {
            backgroundObject.GetComponent<Image>().sprite = summerDaytimeBGSprite;
            skyObject.GetComponent<Image>().sprite = summerDaytimeSkySprite;
            spectatorObject.GetComponent<Image>().sprite = daytimeSpectatorSprite;
            currentStage.GetComponent<Image>().sprite = stage1;

            cloud.SetActive(true);
            summerDaytimeBird.SetActive(true);

            myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = myKoalaDaytimeAnim.runtimeAnimatorController;
            counterKoalaObj.GetComponent<Animator>().runtimeAnimatorController = farmerKoalaAnim.runtimeAnimatorController;
        }

        else if(saveData.currentSelectedStage == saveData.stageList[2])
        {
            backgroundObject.GetComponent<Image>().sprite = sunsetBGSprite;
            skyObject.GetComponent<Image>().sprite = sunsetSkySprite;
            spectatorObject.GetComponent<Image>().sprite = sunsetSpectatorSprite;
            currentStage.GetComponent<Image>().sprite = stage3;

            sun.SetActive(true);
            sunsetBird.SetActive(true);

            myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = myKoalaSunsetAnim.runtimeAnimatorController;
            counterKoalaObj.GetComponent<Animator>().runtimeAnimatorController = hunterKoalaAnim.runtimeAnimatorController;
        }

        else if(saveData.currentSelectedStage == saveData.stageList[1])
        {
            backgroundObject.GetComponent<Image>().sprite = summerNightBGSprite;
            skyObject.GetComponent<Image>().sprite = summerNightSkySprite;
            spectatorObject.GetComponent<Image>().sprite = nightSpectatorSprite;
            currentStage.GetComponent<Image>().sprite = stage2;

            star.SetActive(true);

            myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = myKoalaNightAnim.runtimeAnimatorController;
            counterKoalaObj.GetComponent<Animator>().runtimeAnimatorController = babyKoalaAnim.runtimeAnimatorController;
        }

        else if(saveData.currentSelectedStage == saveData.stageList[3])
        {
            backgroundObject.GetComponent<Image>().sprite = fallDaytimeBGSprite;
            skyObject.GetComponent<Image>().sprite = fallDaytimeSkySprite;
            spectatorObject.GetComponent<Image>().sprite = daytimeSpectatorSprite;
            currentStage.GetComponent<Image>().sprite = stage4;

            cloud.SetActive(true);
            fallDaytimeBird.SetActive(true);

            myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = myKoalaDaytimeAnim.runtimeAnimatorController;
            counterKoalaObj.GetComponent<Animator>().runtimeAnimatorController = sleepyKoalaAnim.runtimeAnimatorController;
        }

        else if(saveData.currentSelectedStage == saveData.stageList[4])
        {
            backgroundObject.GetComponent<Image>().sprite = fallNightBGSprite;
            skyObject.GetComponent<Image>().sprite = fallNightSkySprite;
            spectatorObject.GetComponent<Image>().sprite = nightSpectatorSprite;
            currentStage.GetComponent<Image>().sprite = stage5;

            star.SetActive(true);

            myKoalaObj.GetComponent<Animator>().runtimeAnimatorController = myKoalaNightAnim.runtimeAnimatorController;
            counterKoalaObj.GetComponent<Animator>().runtimeAnimatorController = grandfaKoalaAnim.runtimeAnimatorController;
        }
    }
}
