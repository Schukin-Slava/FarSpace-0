using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthPickUp : MonoBehaviour
{
    public int HealthRegen = 20;
    public AudioClip soundToPlay;
    public float volume = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageAble damageable = collision.GetComponent<DamageAble>();
        if (damageable)
        {
            bool wasHealed = damageable.Heal(HealthRegen);
            if (wasHealed)
            {
                AudioSource.PlayClipAtPoint(soundToPlay, gameObject.transform.position, volume);
                Destroy(gameObject);
            }
            
        }
    }
}
