using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

//--------------------------------------------- Variables ---------------------------------------------------
    [SerializeField] float backgroundScrollSpeed = 0.2f;
    Material myMaterial;
    Vector2 offset;




//------------------------------------------ Start & Update -------------------------------------------------
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, backgroundScrollSpeed);
    }
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
