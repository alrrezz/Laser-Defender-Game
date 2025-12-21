using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
//------------------------------------------ Start & Update -------------------------------------------------
    void Awake()
    {
        SetUpSingelton();
    }


//---------------------------------------------- Methods ----------------------------------------------------
    private void SetUpSingelton()
    {
        if(FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
}
