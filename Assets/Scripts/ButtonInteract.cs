using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private Door door;
    Animator animator;
    public AudioClip soundToPlay;
    public float volume = 1f;

    private void Awake()
    {
        door = doorGameObject.GetComponent<Door>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!animator.GetBool(AnimationStrings.IsPushed))
        {
            AudioSource.PlayClipAtPoint(soundToPlay, gameObject.transform.position, volume);
            animator.SetBool(AnimationStrings.IsPushed, true);
            door.OpenDoor();
        }
    }
}
