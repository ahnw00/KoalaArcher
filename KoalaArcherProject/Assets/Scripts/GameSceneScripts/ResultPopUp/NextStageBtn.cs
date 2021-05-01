using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageBtn : MonoBehaviour
{
  public void NextStage()
  {
      SceneLoadManager.instance.LoadScene("StageScene");
  }
}
