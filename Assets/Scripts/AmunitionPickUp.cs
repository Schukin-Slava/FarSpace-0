using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class AmunitionPickUp : MonoBehaviour
{

    public int amunitionGet = 20;
    public AudioClip soundToPlay;
    public float volume = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageAble damageable = collision.GetComponent<DamageAble>();
        if (damageable)
        {
            bool wasIncrease = damageable.GetBullett(amunitionGet);
            if (wasIncrease)
            {
                AudioSource.PlayClipAtPoint(soundToPlay, gameObject.transform.position, volume);
                Destroy(gameObject);
            }

        }
    }
}
