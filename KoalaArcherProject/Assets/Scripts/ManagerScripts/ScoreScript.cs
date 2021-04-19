using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public InGameManager inGameManager;
    public Text textprefab;
    Text scoreText;
  
    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
        
    }

    public void InstantiationOfScoreText()
    {
        /*
        while(true)
        {
            yield return null;
            if(!inGameManager.whileShooting)
            {
                scoreText = Instantiate(textprefab, new Vector3(-295 + 64.5f * inGameManager.orderOfShot, 17, 0), textprefab.transform.rotation);
                scoreText.transform.SetParent(this.transform);
            }
        }*/
    }
  
}
