using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSystem : MonoBehaviour
{
    //config parameters
    [SerializeField] GameObject explosionParticelPrefab;
    [SerializeField] float durationOfExplosion = 1f;


    public void ExplosionVFX()
    {
        var explosionVFX = Instantiate
            (explosionParticelPrefab,
            transform.position,
            Quaternion.identity);

        Destroy
        (explosionVFX,
        durationOfExplosion);
    }
}
