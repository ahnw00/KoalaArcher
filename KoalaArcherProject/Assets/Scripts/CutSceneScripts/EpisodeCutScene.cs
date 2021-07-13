using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EpisodeCutScene : MonoBehaviour
{
    [Header("Set in Editor")]
    [SerializeField] CanvasGroup scene1;
    [SerializeField] CanvasGroup scene2;
    [SerializeField] CanvasGroup scene3;
    [SerializeField] CanvasGroup scene4;
    [SerializeField] CanvasGroup scene5;
    [SerializeField] CanvasGroup scene6;
    [SerializeField] CanvasGroup scene7;


    [Header("Set in Runtime")]
    private int processIndex = 0;
    private float fadeTime = 0.8f;
    bool Lock = false;

    GameManager gameManager;
    SaveDataClass saveData;
    int currentStageNum;

    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        currentStageNum = saveData.currentStageIndex + 1;
        PrologueProgress(0);
    }

    private void PrologueProgress(int processIndex)
    {
        if (currentStageNum == 1)
        {
            if (processIndex == 0)
            {
                //StartCoroutine(FadeBackground(scene1, scene1));
            }
            else if (processIndex == 1)
            {
                StartCoroutine(FadeBackground(scene2, scene1));
            }
            else if (processIndex == 2)
            {
                StartCoroutine(FadeBackground(scene3, scene2));
            }
            else if (processIndex == 3)
            {
                StartCoroutine(FadeBackground(scene4, scene3));
            }
            else if (processIndex == 4)
            {
                StartCoroutine(FadeBackground(scene5, scene4));
            }
            else if (processIndex == 5)
            {
                StartCoroutine(FadeBackground(scene6, scene5));
            }
            else
            {
                if (Lock == false) // 씬 이동, lock true로 변경
                {
                    SceneLoadManager.instance.LoadScene("StageScene");
                    Lock = true;
                }
            }
        }
        else if (currentStageNum == 2)
        {
            if (processIndex == 0)
            {
                //StartCoroutine(FadeBackground(scene1, scene1));
            }
            else if (processIndex == 1)
            {
                StartCoroutine(FadeBackground(scene2, scene1));
            }
            else if (processIndex == 2)
            {
                StartCoroutine(FadeBackground(scene3, scene2));
            }
            else if (processIndex == 3)
            {
                StartCoroutine(FadeBackground(scene4, scene3));
            }
            else if (processIndex == 4)
            {
                StartCoroutine(FadeBackground(scene5, scene4));
            }
            else if (processIndex == 5)
            {
                StartCoroutine(FadeBackground(scene6, scene5));
            }
            else if (processIndex == 6)
            {
                StartCoroutine(FadeBackground(scene7, scene6));
            }
            else
            {
                if (Lock == false) // 씬 이동, lock true로 변경
                {
                    SceneLoadManager.instance.LoadScene("StageScene");
                    Lock = true;
                }
            }
        }
        else if (currentStageNum == 3)
        {
            if (processIndex == 0)
            {
                //StartCoroutine(FadeBackground(scene1, scene1));
            }
            else if (processIndex == 1)
            {
                StartCoroutine(FadeBackground(scene2, scene1));
            }
            else if (processIndex == 2)
            {
                StartCoroutine(FadeBackground(scene3, scene2));
            }
            else if (processIndex == 3)
            {
                StartCoroutine(FadeBackground(scene4, scene3));
            }
            else if (processIndex == 4)
            {
                StartCoroutine(FadeBackground(scene5, scene4));
            }
            else if (processIndex == 5)
            {
                StartCoroutine(FadeBackground(scene6, scene5));
            }
            //컷씬 이미지 개수에 따라 수정
            else
            {
                if (Lock == false) // 씬 이동, lock true로 변경
                {
                    SceneLoadManager.instance.LoadScene("StageScene");
                    Lock = true;
                }
            }
        }
        else
        {
            if (processIndex == 0)
            {
                //StartCoroutine(FadeBackground(scene1, scene1));
            }
            else if (processIndex == 1)
            {
                StartCoroutine(FadeBackground(scene2, scene1));
            }
            else if (processIndex == 2)
            {
                StartCoroutine(FadeBackground(scene3, scene2));
            }
            else if (processIndex == 3)
            {
                StartCoroutine(FadeBackground(scene4, scene3));
            }
            else if (processIndex == 4)
            {
                StartCoroutine(FadeBackground(scene5, scene4));
            }
            else if (processIndex == 5)
            {
                StartCoroutine(FadeBackground(scene6, scene5));
            }
            //컷씬 이미지 개수에 따라 수정
            else
            {
                if (Lock == false) // 씬 이동, lock true로 변경
                {
                    SceneLoadManager.instance.LoadScene("StageScene");
                    Lock = true;
                }
            }
        }
    }

    IEnumerator FadeBackground(CanvasGroup fadeIn, CanvasGroup fadeOut)
    {
        float timeElapsed = 0f;
        while (timeElapsed < fadeTime)
        {
            fadeIn.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeTime);
            yield return 0;
            timeElapsed += Time.deltaTime;
        }
        fadeIn.alpha = 1f;
        fadeOut.alpha = 0f;
    }

    public void OnClickNextPanel() // Panel 클릭 시
    {
        processIndex++;
        PrologueProgress(processIndex);
    }
}