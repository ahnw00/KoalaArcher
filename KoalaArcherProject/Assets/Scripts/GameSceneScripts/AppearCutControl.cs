using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearCutControl : MonoBehaviour
{
    InGameManager inGameManager;
    public GameObject appearCutParent;
    public GameObject touchPanel;
    
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
    }

    public void SetActiveFalse()
    {
        touchPanel.SetActive(true);
        appearCutParent.SetActive(false);
        inGameManager.isPaused = false;
    }
}
