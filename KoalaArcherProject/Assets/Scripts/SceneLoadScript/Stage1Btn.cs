using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Btn : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
