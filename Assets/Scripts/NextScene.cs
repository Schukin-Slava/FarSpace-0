using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public AudioClip soundToPlay;
    public float volume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(soundToPlay, gameObject.transform.position, volume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
