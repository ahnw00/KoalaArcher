using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    GameManager gameManager;
    SaveDataClass saveData;
    int orderOfShot;
    public InGameManager inGameManager;
    public CounterKoala counterKoala;
    SpriteManager spriteManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleTon;
        saveData = gameManager.saveData;
        
        inGameManager = FindObjectOfType<InGameManager>();
        orderOfShot = inGameManager.orderOfShot;

        spriteManager = FindObjectOfType<SpriteManager>();
        counterKoala = FindObjectOfType<CounterKoala>();
    }

    void Update()
    {

    }

    public void AngleAimingAnim()
    {
        inGameManager.StopAllCoroutines();
        inGameManager.StartCoroutine(inGameManager.PowerGaugeCoroutine());
        inGameManager.angleBarObj.SetActive(false);
        inGameManager.powerBarObj.SetActive(true);
        inGameManager.isPaused = false;
        gameObject.SetActive(false);
    }

    public void PowerGaugeAnim()
    {
        inGameManager.isPaused = false;
        this.gameObject.GetComponent<Animator>().speed = 1f;
        inGameManager.powerBarObj.SetActive(false);
        inGameManager.myKoalaAnim.SetActive(false);
        counterKoala.counterImage.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PauseCoroutine()
    {
        inGameManager.isPaused = true;
    }

    public void PauseAnim()
    {
        this.gameObject.GetComponent<Animator>().speed = 0f;
        StartCoroutine(WaitForSeconds(0.3f));
    }

    IEnumerator WaitForSeconds(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        this.gameObject.GetComponent<Animator>().speed = 1f;
    }
}
