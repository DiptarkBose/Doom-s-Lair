using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour, ITrapInterface
{
    private bool bIsActivated;
    private Animator mAnimator;

    [SerializeField]
    private GameObject SpikeGameObject;

    private void Start()
    {
        if (SpikeGameObject != null)
        {
            mAnimator = SpikeGameObject.GetComponentInChildren<Animator>();
        }
        bIsActivated = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        ActivateTrap();
    }

    private void OnTriggerExit(Collider other)
    {
        ActivateTrap();
    }

    void ITrapInterface.TriggerTrap()
    {
        ActivateTrap();
    }

    void ActivateTrap()
    {
        
        if (mAnimator != null)
        {
            Debug.Log(SpikeGameObject.transform.position);
            if (bIsActivated)
            {
                Debug.Log("DEACTIVATE");
                mAnimator.SetTrigger("TrDeactivate");
                //SpikeGameObject.transform.position = SpikeGameObject.transform.position - new Vector3(0.0f, 0.875f, 0.0f);
                Debug.Log(SpikeGameObject.transform.position);
            }
            else
            {
                Debug.Log("ACTIVATE");
                mAnimator.SetTrigger("TrActivate");
                FindObjectOfType<AudioManager>().Play("Spike");
                //SpikeGameObject.transform.position = SpikeGameObject.transform.position + new Vector3(0.0f, 0.875f, 0.0f);
                Debug.Log(SpikeGameObject.transform.position);
            }
            bIsActivated = !bIsActivated;
        }
    }
}
