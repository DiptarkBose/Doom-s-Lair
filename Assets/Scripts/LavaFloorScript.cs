using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloorScript : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource adSrc;
    bool manInPit = false;
    Animator playerAnimator;
    void Start()
    {
        adSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manInPit)
        {
            if (!AnimatorIsPlaying())
                playerAnimator.Play("Jumping");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        adSrc.Play();
        playerAnimator = other.GetComponent<Animator>();
        manInPit = true;
    }
    private void OnTriggerExit(Collider other)
    {
        adSrc.Stop();
        manInPit = false;
    }
    bool AnimatorIsPlaying()
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).length >
               playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
