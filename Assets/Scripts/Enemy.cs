using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

//--------------------------------------------- Variables ---------------------------------------------------
    //configuration parameters
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject enemyLaserPrefab;

    //cashed references
    SFXPlayer soundPlayer;
    HealthSystem healthSystem;
    float shotCounter;






//------------------------------------------ Start & Update -------------------------------------------------
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        soundPlayer = GetComponent<SFXPlayer>();
        healthSystem = GetComponent<HealthSystem>();
    }
    void Update()
    {
        HandleFire();
    }






//---------------------------------------------- Methods ----------------------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = 
            other.GetComponent<DamageDealer>();

        if (!damageDealer) { return; }
        healthSystem.ProcessHit(damageDealer);
    }
    private void HandleFire()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();

            shotCounter = Random.Range
                (minTimeBetweenShots, 
                maxTimeBetweenShots);
        }
    }
    private void Fire()
    {
        GameObject laser = Instantiate(
            enemyLaserPrefab, 
            transform.position, 
            Quaternion.identity) as GameObject;

        laser.GetComponent<Rigidbody2D>().velocity = 
            new Vector2(0, -projectileSpeed);

        soundPlayer.PlayShootSFX();
    }
}
