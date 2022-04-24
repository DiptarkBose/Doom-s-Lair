using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrap : MonoBehaviour, ITrapInterface
{
    AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void ITrapInterface.TriggerTrap()
    {
        Debug.Log("TRAP TRIGGERED");
        audioSrc.Play();
        Vector3 temp = gameObject.transform.position;
        temp.y += 10;
        gameObject.transform.position = temp;
    }
}
