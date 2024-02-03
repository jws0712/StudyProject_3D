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

    public static ScoreManager Instance = null;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }    
    }

    void Start()
    {
        BestSocre = PlayerPrefs.GetInt("Best Score", 0);

        BestScoreUI.text = "�ְ� ����: " + BestSocre;
    }


    public int Score
    {
        get
        {
            return currentSocre;
        }
        set
        {
            currentSocre = value;

            currentSocreUI.text = "���� ����: " + currentSocre;

            if (currentSocre > BestSocre)
            {
                BestSocre = currentSocre;

                BestScoreUI.text = "�ְ� ����: " + BestSocre;

                PlayerPrefs.SetInt("Best Score", BestSocre);
            }
        }
    }
}
