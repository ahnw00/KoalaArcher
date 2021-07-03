using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBoardManager : MonoBehaviour
{
    InGameManager inGameManager;
    CounterKoala counterKoala;

    public Sprite daytimeTen;
    public Sprite daytimeNine;
    public Sprite daytimeEight;
    public Sprite daytimeSeven;
    public Sprite daytimeSix;
    public Sprite daytimeZero;

    public Sprite sunsetTen;
    public Sprite sunsetNine;
    public Sprite sunsetEight;
    public Sprite sunsetSeven;
    public Sprite sunsetSix;
    public Sprite sunsetZero;

    public Sprite nightTen;
    public Sprite nightNine;
    public Sprite nightEight;
    public Sprite nightSeven;
    public Sprite nightSix;
    public Sprite nightZero;

    // Start is called before the first frame update
    void Start()
    {
        inGameManager = FindObjectOfType<InGameManager>();
        counterKoala = FindObjectOfType<CounterKoala>();

        StartCoroutine(TargetBoardCoroutine());
    }

    public IEnumerator TargetBoardCoroutine()
    {
        while(true)
        {
            yield return null;

            //1스테이지
            if(inGameManager.stage == inGameManager.saveData.stageList[0])
            {
                //내가 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                if(inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 10)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeTen;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 9)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeNine;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 8)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeEight;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 7)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeSeven;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 6)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeSix;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 0)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeZero;
                    }
                }
                //상대방이 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                else if(!inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 10)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeTen;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 9)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeNine;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 8)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeEight;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 7)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeSeven;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 6)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeSix;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 0)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeZero;
                    }
                }
                //만약 샷을 쏜게 아니라면 과녁엔 계속 화살이 안 박혀 있어야 해.
                if(!inGameManager.isShotFinished)
                {
                    gameObject.GetComponent<Image>().sprite = daytimeZero;
                }
            }

            //3스테이지
            else if(inGameManager.stage == inGameManager.saveData.stageList[2])
            {
                //내가 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                if(inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 10)
                    {
                        gameObject.GetComponent<Image>().sprite = sunsetTen;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 9)
                    {
                        gameObject.GetComponent<Image>().sprite = sunsetNine;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 8)
                    {
                        gameObject.GetComponent<Image>().sprite = sunsetEight;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 7)
                    {
                        gameObject.GetComponent<Image>().sprite = sunsetSeven;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 6)
                    {
                        gameObject.GetComponent<Image>().sprite = sunsetSix;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 0)
                    {
                        gameObject.GetComponent<Image>().sprite = sunsetZero;
                    }
                }
                //상대방이 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                else if(!inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 10)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = sunsetTen;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 9)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = sunsetNine;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 8)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = sunsetEight;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 7)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = sunsetSeven;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 6)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = sunsetSix;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 0)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = sunsetZero;
                    }
                }
                //만약 샷을 쏜게 아니라면 과녁엔 계속 화살이 안 박혀 있어야 해.
                if(!inGameManager.isShotFinished)
                {
                    gameObject.GetComponent<Image>().sprite = sunsetZero;
                }
            }

            //2스테이지
            else if(inGameManager.stage == inGameManager.saveData.stageList[1])
            {
                //내가 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                if(inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 10)
                    {
                        gameObject.GetComponent<Image>().sprite = nightTen;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 9)
                    {
                        gameObject.GetComponent<Image>().sprite = nightNine;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 8)
                    {
                        gameObject.GetComponent<Image>().sprite = nightEight;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 7)
                    {
                        gameObject.GetComponent<Image>().sprite = nightSeven;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 6)
                    {
                        gameObject.GetComponent<Image>().sprite = nightSix;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 0)
                    {
                        gameObject.GetComponent<Image>().sprite = nightZero;
                    }
                }
                //상대방이 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                else if(!inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 10)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightTen;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 9)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightNine;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 8)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightEight;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 7)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightSeven;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 6)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightSix;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 0)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightZero;
                    }
                }
                //만약 샷을 쏜게 아니라면 과녁엔 계속 화살이 안 박혀 있어야 해.
                if(!inGameManager.isShotFinished)
                {
                    gameObject.GetComponent<Image>().sprite = nightZero;
                }
            }

            //4스테이지
            else if(inGameManager.stage == inGameManager.saveData.stageList[3])
            {
                //내가 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                if(inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 10)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeTen;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 9)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeNine;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 8)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeEight;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 7)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeSeven;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 6)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeSix;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 0)
                    {
                        gameObject.GetComponent<Image>().sprite = daytimeZero;
                    }
                }
                //상대방이 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                else if(!inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 10)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeTen;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 9)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeNine;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 8)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeEight;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 7)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeSeven;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 6)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeSix;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 0)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = daytimeZero;
                    }
                }
                //만약 샷을 쏜게 아니라면 과녁엔 계속 화살이 안 박혀 있어야 해.
                if(!inGameManager.isShotFinished)
                {
                    gameObject.GetComponent<Image>().sprite = daytimeZero;
                }
            }

            //5스테이지
            else if(inGameManager.stage == inGameManager.saveData.stageList[4])
            {
                //내가 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                if(inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 10)
                    {
                        gameObject.GetComponent<Image>().sprite = nightTen;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 9)
                    {
                        gameObject.GetComponent<Image>().sprite = nightNine;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 8)
                    {
                        gameObject.GetComponent<Image>().sprite = nightEight;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 7)
                    {
                        gameObject.GetComponent<Image>().sprite = nightSeven;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 6)
                    {
                        gameObject.GetComponent<Image>().sprite = nightSix;
                    }
                    else if(inGameManager.scoreList[inGameManager.orderOfShot - 1] == 0)
                    {
                        gameObject.GetComponent<Image>().sprite = nightZero;
                    }
                }
                //상대방이 활 쏜 다음에 그 결과에 맞춰서 과녁에 화살이 꽂히도록
                else if(!inGameManager.isMyShot && inGameManager.isShotFinished)
                {
                    if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 10)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightTen;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 9)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightNine;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 8)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightEight;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 7)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightSeven;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 6)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightSix;
                    }
                    else if(counterKoala.counterScore[inGameManager.saveData.currentStageIndex, inGameManager.orderOfShot - 1] == 0)
                    {
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Image>().sprite = nightZero;
                    }
                }
                //만약 샷을 쏜게 아니라면 과녁엔 계속 화살이 안 박혀 있어야 해.
                if(!inGameManager.isShotFinished)
                {
                    gameObject.GetComponent<Image>().sprite = nightZero;
                }
            }
        }
    }
}
