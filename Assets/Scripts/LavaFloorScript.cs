using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloorScript : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource adSrc;
    void Start()
    {
        adSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        adSrc.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        adSrc.Stop();
    }
}
