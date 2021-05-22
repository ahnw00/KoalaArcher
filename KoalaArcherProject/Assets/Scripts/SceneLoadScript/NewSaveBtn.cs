using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSaveBtn : MonoBehaviour
{
    public void LoadStageScene()
    {
        SceneLoadManager.instance.LoadScene("CutScene");
    }
}
