using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject EndTxt;

    public int cardCount = 0;
    float time = 0.0f;
    float totalTime = 30.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 30.0f)
        {
            EndTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
        //ÆÄ±«ÇØ¶ó.
        firstCard.DestroyCard();
        secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0) 
            {
                Time.timeScale = 0.0f;
                EndTxt.SetActive(true);
            }
        }
        else 
        {
            //´Ý¾Æ¶ó.
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }
}
