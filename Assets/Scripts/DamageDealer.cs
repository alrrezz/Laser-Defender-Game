using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

//--------------------------------------------- Variables ---------------------------------------------------
    [SerializeField] int damage = 1;
    VFXSystem explosion;






//------------------------------------------ Start & Update -------------------------------------------------
    private void Start()
    {
        explosion = GetComponent<VFXSystem>();
    }




//---------------------------------------------- Methods ----------------------------------------------------
    public int GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        Destroy(gameObject);
        explosion.ExplosionVFX();
    }
}
