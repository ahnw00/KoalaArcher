using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotClock : MonoBehaviour
{
    InGameManager inGameManager;
    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
    }

    public void showMyShotResult()
    {
        inGameManager.isMyShot = true;
        inGameManager.isShotFinished = true;
    }

    public void showRivalShotResult()
    {
        inGameManager.isMyShot = false;
        inGameManager.isShotFinished = true;
    }

    public void resetShotResult()
    {
        inGameManager.isShotFinished = false;
    }
}
