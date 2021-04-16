using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public InGameManager inGameManager;
    public TouchPanelScript touchPanelScript;
    
  
    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
    }

    public void ScoreFunction()
    {
        for(int i = 0 ;i < 10; i++){
            if (inGameManager.scoreList[i] == null)
                inGameManager.scoreList.Add(inGameManager.amingScoreList[i] * 4 + inGameManager.powerScoreList[i] * 2);
            switch(inGameManager.scoreList[i]){
                case 8:
                inGameManager.scoreList[i]=9;
                break;

                case 6:
                inGameManager.scoreList[i]=8;
                break;

                case 4:
                inGameManager.scoreList[i]=7;
                break;

                case 2:
                inGameManager.scoreList[i]=6;
                break;

                case 0:
                inGameManager.scoreList[i]=0;
                break; 
            }
        }
    }


    
    
    
}
