using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentSocreUI;
    private int currentSocre;

    public Text BestScoreUI;

    private int BestSocre;
    // Start is called before the first frame update
    void Start()
    {
        BestSocre = PlayerPrefs.GetInt("Best Score", 0);

        BestScoreUI.text = "최고 점수: " + BestSocre;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int value)
    {
        currentSocre = value;

        currentSocreUI.text = "현재 점수: " + currentSocre;

        if (currentSocre > BestSocre)
        {
            BestSocre = currentSocre;

            BestScoreUI.text = "최고 점수: " + BestSocre;

            PlayerPrefs.SetInt("Best Score", BestSocre);
        }
    }

    public int GetSocre()
    {
        return currentSocre;
    }
}
