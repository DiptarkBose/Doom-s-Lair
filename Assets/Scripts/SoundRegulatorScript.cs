using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRegulatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSrc.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        audioSrc.Stop();
    }
}
