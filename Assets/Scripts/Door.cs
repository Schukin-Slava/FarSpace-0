using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioClip soundToPlay;
    public float volume = 1f;
    Animator animator;
    public void OpenDoor()
    {
        AudioSource.PlayClipAtPoint(soundToPlay, gameObject.transform.position, volume);
        animator.SetBool(AnimationStrings.IsPushed, true);

    }
    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

}
