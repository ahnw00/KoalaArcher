using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSetting : MonoBehaviour
{
    GameManager gameManager;
    public GameObject SettingPopUp;

    void Start()
    {
        gameManager = GameManager.singleTon;
    }

    public void onClickSettingBtn()
    {
        SettingPopUp.SetActive(true);
    }

    public void onClickCloseBtn()
    {
        SettingPopUp.SetActive(false);
        gameManager.Save();
    }
}