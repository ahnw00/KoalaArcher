using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public GameObject panel;

    [Header("Set in Editor")]
    [SerializeField] CanvasGroup scene1;
    [SerializeField] CanvasGroup scene2;
    [SerializeField] CanvasGroup scene3;
    [SerializeField] CanvasGroup scene4;
    [SerializeField] CanvasGroup scene5;
    [SerializeField] CanvasGroup scene6;
    [SerializeField] CanvasGroup scene7;
    [SerializeField] CanvasGroup scene8;
    [SerializeField] CanvasGroup scene9;
    [SerializeField] CanvasGroup scene10;


    [Header("Set in Runtime")]
    private int processIndex = 0;
    private float fadeTime = 0.8f;
    bool Lock = false;

    void Start()
    {
        EndingProgress(0);
    }

    private void EndingProgress(int processIndex)
    {
        if (processIndex == 0)
        {
            WaitForNextClick();
            //StartCoroutine(FadeBackground(scene1, scene1));
        }
        else if (processIndex == 1)
        {
            StartCoroutine(FadeBackground(scene2, scene1));
            WaitForNextClick();
        }
        else if (processIndex == 2)
        {
            StartCoroutine(FadeBackground(scene3, scene2));
            WaitForNextClick();
        }
        else if (processIndex == 3)
        {
            StartCoroutine(FadeBackground(scene4, scene3));
            WaitForNextClick();
        }
        else if (processIndex == 4)
        {
            StartCoroutine(FadeBackground(scene5, scene4));
            WaitForNextClick();
        }
        else if (processIndex == 5)
        {
            StartCoroutine(FadeBackground(scene6, scene5));
            WaitForNextClick();
        }
        else if (processIndex == 6)
        {
            StartCoroutine(FadeBackground(scene7, scene6));
            WaitForNextClick();
        }
        else if (processIndex == 7)
        {
            StartCoroutine(FadeBackground(scene8, scene7));
            WaitForNextClick();
        }
        else if (processIndex == 8)
        {
            StartCoroutine(FadeBackground(scene9, scene8));
            WaitForNextClick();
        }
        else if (processIndex == 9)
        {
            StartCoroutine(FadeBackground(scene10, scene9));
            WaitForNextClick();
        }
        else
        {
            if (Lock == false) // 씬 이동, lock true로 변경
            {
                SceneLoadManager.instance.LoadScene("MainScene");
                Lock = true;
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
        EndingProgress(processIndex);
    }

    public void WaitForNextClick()
    {
        panel.SetActive(false);
        Invoke("FinishWaiting", 2f);
    }

    public void FinishWaiting()
    {
        panel.SetActive(true);
    }
}
