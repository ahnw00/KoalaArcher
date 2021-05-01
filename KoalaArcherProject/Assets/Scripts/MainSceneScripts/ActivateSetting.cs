using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSetting : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    public GameObject SettingPopUp;

    public void onClickSettingBtn()
    {
        SettingPopUp.SetActive(true);
    }

    public void onClickCloseBtn()
    {
        SettingPopUp.SetActive(false);
    }
}