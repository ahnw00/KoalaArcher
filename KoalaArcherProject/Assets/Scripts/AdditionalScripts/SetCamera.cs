using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCamera : MonoBehaviour
{
    void OnEnable()
    {
        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
}
