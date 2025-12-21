using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

//--------------------------------------------- Variables ---------------------------------------------------
    //config parameters
    [SerializeField] int health = 100;
    [SerializeField] int scoreValue = 150;

    //cashed references
    VFXSystem explosion;
    SFXPlayer soundPlayer;
    GameSession gameSession;



//------------------------------------------ Start & Update -------------------------------------------------
    private void Start()
    {
        explosion = GetComponent<VFXSystem>();
        soundPlayer = GetComponent<SFXPlayer>();
        gameSession = FindObjectOfType<GameSession>();
    }




//---------------------------------------------- Methods ----------------------------------------------------
    public void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0){ Die(); }
    }
    private void Die()
    {
        Destroy(gameObject);
        explosion.ExplosionVFX();
        soundPlayer.PlayDeathSFX();

        if (CompareTag("Player"))
        {
            FindObjectOfType<LevelManager>().LoadGameOverMenu();
            return;
        }
        gameSession.UpdateScore(scoreValue);
    }
    public int GetHealth(){ return health; }
}
