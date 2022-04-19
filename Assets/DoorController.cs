using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject keyRequiredInstruction;
    public GameObject doorOpenInstruction;
    private bool doorReadyToOpen;
    public Animator anim;


    private AttributeSet attributeSet;
    private Animator playerAnimator;
    private AudioSource doorAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        keyRequiredInstruction.SetActive(false);
        doorOpenInstruction.SetActive(false);
        doorReadyToOpen = false;
        doorAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doorReadyToOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("DoorOpen");
                playerAnimator.Play("Interact");
                doorAudioSource.PlayDelayed(2);
                BoxCollider doorBx = GetComponent<BoxCollider>();
                doorBx.enabled = false;
                attributeSet.GetType().GetField("KeyPieceCount").SetValue(attributeSet, 0);
                doorOpenInstruction.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController)
        {
            attributeSet = playerController.attributeSet;
            float keyNum = (float)attributeSet.GetType().GetField("KeyPieceCount").GetValue(attributeSet);
            if(keyNum < 1)
            {
                keyRequiredInstruction.SetActive(true);
            }
            else
            {
                doorOpenInstruction.SetActive(true);
                playerAnimator = other.GetComponent<Animator>();
                doorReadyToOpen = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        keyRequiredInstruction.SetActive(false);
        doorOpenInstruction.SetActive(false);
        doorReadyToOpen = false;
    }
}
