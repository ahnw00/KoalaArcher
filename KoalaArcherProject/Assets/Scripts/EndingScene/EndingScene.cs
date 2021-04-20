using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndingScene : MonoBehaviour
{
    [Header("Set in Editor")]
    [SerializeField] CanvasGroup scene1;
    [SerializeField] CanvasGroup scene2;
    [SerializeField] CanvasGroup scene3;
    [SerializeField] CanvasGroup scene4;
    [SerializeField] CanvasGroup scene5;

    [Header("Set in Runtime")]
    private int processIndex = 0;
    private float fadeTime = 0.8f;
    bool Lock = false;

    void Start()
    {
        PrologueProgress(0);
    }

    private void PrologueProgress(int processIndex)
    {
        if (processIndex == 0)
        {
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
        else if (processIndex==5)
        {
            if(Lock == false){
                Lock=true;
                SceneLoadManager.instance.LoadScene("StageScene");
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

    public void OnClickNextPanel() // Panel 클릭 시! 
    {
        processIndex++;
        PrologueProgress(processIndex);
    }
}
