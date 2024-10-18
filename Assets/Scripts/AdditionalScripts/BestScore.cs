using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    public List<GameObject> textList;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;

        for(int i = 0; i < 5; i++)
        {
            if(this.gameObject == textList[i])
            {
                this.gameObject.GetComponent<Text>().text = saveData.stageList[i].bestScore.ToString();
            }
        }
    }

    
}
