using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{

    //configuration parameters------------------------------------------------------------------------

    [SerializeField] AudioClip[] deathSound;
    [Range(0, 1)][SerializeField] float deathSoundVolume = 0.5f;
    [SerializeField] AudioClip shootSound;
    [Range(0, 1)][SerializeField] float shootSoundVolume = 0.5f;

    //------------------------------------------------------------------------------------------------


    public void PlayDeathSFX()
    {
        int random = Random.Range(0, deathSound.Length - 1);
        AudioSource.PlayClipAtPoint(deathSound[random], Camera.main.transform.position, deathSoundVolume);
    }
    public void PlayShootSFX()
    {
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }
}
