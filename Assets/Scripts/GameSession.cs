using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

//--------------------------------------------- Variables ---------------------------------------------------
    int score = 0;



//------------------------------------------ Start & Update -------------------------------------------------
    void Awake()
    {
        SetUpSingelton();
    }



//---------------------------------------------- Methods ----------------------------------------------------
    private void SetUpSingelton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public int GetScore(){ return score; }
    public void UpdateScore(int scoreValue){ score += scoreValue; }
    public void ResetGame(){ Destroy(gameObject); }
}
