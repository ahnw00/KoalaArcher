using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainBtn : MonoBehaviour
{
    public void backToMainScene()
    {
        SceneLoadManager.instance.LoadScene("MainScene");
    }
}