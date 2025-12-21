using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SocialPlatforms.Impl;

public class DisplayScore : MonoBehaviour
{

//--------------------------------------------- Variables ---------------------------------------------------
    GameSession score;
    TextMeshProUGUI scoreText;







//------------------------------------------ Start & Update -------------------------------------------------
    void Start()
    {
        score = FindObjectOfType<GameSession>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        scoreText.text = score.GetScore().ToString();
    }
}
