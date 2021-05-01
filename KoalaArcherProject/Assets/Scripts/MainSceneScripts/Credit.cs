using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public GameObject creditPopup;
    public void OnClickedCredit()
    {
        creditPopup.SetActive(true);
    }

    public void OnClickedPanel()
    {
        creditPopup.SetActive(false);
    }

}
