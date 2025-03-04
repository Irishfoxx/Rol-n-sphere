﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text hiScoreText;
    public Text distanceText;
    public Text topDistanceText;

    public float scoreCount;
    public float hiScoreCount;
    public float distanceCount;
    public float topDistanceCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("TopDistance"))
        {
            topDistanceCount = PlayerPrefs.GetFloat("TopDistance");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
            distanceCount += pointsPerSecond * Time.deltaTime;
        }

        

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        if (distanceCount > topDistanceCount)
            {
             topDistanceCount = distanceCount;
             PlayerPrefs.SetFloat("TopDistance", topDistanceCount);
        }
        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);
        distanceText.text = "Distance: " + Mathf.Round(distanceCount);
        topDistanceText.text = "Top Distance: " + Mathf.Round(topDistanceCount);
    }

   public void AddScore (int pointsToAdd)
    {
        scoreCount += pointsToAdd;

    }
}
