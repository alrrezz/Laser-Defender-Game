using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

//--------------------------------------------- Variables ---------------------------------------------------
    //configration parameters
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xPadding = 1f;
    [SerializeField] float yMaxPadding = 12f;
    [SerializeField] float yMinPadding = 2f;
    [SerializeField] Image[] hearts;

    [Header("Projectile")]
    [SerializeField] GameObject playerLaserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;


    //cashed references
    Coroutine firingCoroutine;
    SFXPlayer soundPlayer;
    HealthSystem healthSystem;
    float xMin;
    float xMax;
    float yMin;
    float yMax;




//------------------------------------------ Start & Update -------------------------------------------------
    private void Start()
    {
        SetUpMoveBoundaries();
        soundPlayer = GetComponent<SFXPlayer>();
        healthSystem = GetComponent<HealthSystem>();
    }
    private void Update()
    {
        Move();
        Fire();
    }




//---------------------------------------------- Methods ----------------------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = 
            other.GetComponent<DamageDealer>();

        if (!damageDealer) { return; }
        healthSystem.ProcessHit(damageDealer);
        soundPlayer.PlayDeathSFX();

        
        for (int i = 0; i < hearts.Length; i++)                 //this is for platyer health images
        {
            hearts[i].enabled =i < healthSystem.GetHealth();
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPosition = math.clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPosition = math.clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPosition, newYPosition);
    }

    private void SetUpMoveBoundaries()
    {
        Camera camreaGame = Camera.main;
        if (camreaGame != null)
        {
            xMin = camreaGame.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
            xMax = camreaGame.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
            yMin = camreaGame.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yMinPadding;
            yMax = camreaGame.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yMaxPadding;
        }
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate
                (playerLaserPrefab, 
                transform.position, 
                Quaternion.identity) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = 
                new Vector2(0, projectileSpeed);

            soundPlayer.PlayShootSFX();
            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }
}
