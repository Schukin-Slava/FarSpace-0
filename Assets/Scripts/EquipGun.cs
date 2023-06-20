using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipGun : MonoBehaviour
{

    public AudioClip soundToPlay;
    public float volume = 1f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControler damageable = collision.GetComponent<PlayerControler>();
        if (damageable)
        {
            damageable.GetWeapon(true);

            AudioSource.PlayClipAtPoint(soundToPlay, gameObject.transform.position, volume);
            Destroy(gameObject);


        }
    }
}
