using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameToStageBtn : MonoBehaviour
{
    public void changeToStage()
    {
        SceneManager.LoadScene("StageScene");
    }
}
