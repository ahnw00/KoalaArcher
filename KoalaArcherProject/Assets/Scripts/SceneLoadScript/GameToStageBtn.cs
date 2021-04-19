using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameToStageBtn : MonoBehaviour
{
    public void changeToStage()
    {
        SceneLoadManager.instance.LoadScene("StageScene");
    }
}
