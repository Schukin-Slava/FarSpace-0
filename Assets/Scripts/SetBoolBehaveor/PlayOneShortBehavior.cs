using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShortBehavior : StateMachineBehaviour
{

    public AudioClip soundToPlay;
    public float volume = 1f;
    public bool PlayOnEnter = true;
    public bool PlayOnExit = false;
    public bool playAfterDelay = false;


    public float playDelay = 0.25f;
    private float timeSinceEntered = 0;
    private bool hasDelayedSoundPLayed = false;
   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayOnEnter)
        {
            AudioSource.PlayClipAtPoint(soundToPlay, animator.gameObject.transform.position, volume);
        }
        timeSinceEntered = 0F;
        hasDelayedSoundPLayed = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playAfterDelay && !hasDelayedSoundPLayed)
        {

            timeSinceEntered += Time.deltaTime;
            if (timeSinceEntered > playDelay)
            {
                AudioSource.PlayClipAtPoint(soundToPlay,animator.gameObject.transform.position, volume);
                hasDelayedSoundPLayed = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayOnExit)
        {
            AudioSource.PlayClipAtPoint(soundToPlay, animator.gameObject.transform.position, volume);
        }
    }


}
