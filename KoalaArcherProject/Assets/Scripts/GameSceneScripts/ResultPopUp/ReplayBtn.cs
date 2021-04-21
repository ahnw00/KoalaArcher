using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayBtn : MonoBehaviour
{   
    public void Replay()
    {
        SceneLoadManager.instance.LoadScene("GameScene");
    }
}
