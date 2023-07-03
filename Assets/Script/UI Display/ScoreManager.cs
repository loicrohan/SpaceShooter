﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score : " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(float score)
    {
        _scoreText.text = "Score : " + score.ToString();
    }
}