using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleteScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameCompletePanel;
    public GameObject bgAudioObject;
    AudioSource audioSource, bg;
    void Start()
    {
        gameCompletePanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        bg = bgAudioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        gameCompletePanel.SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            bg.Stop();
        }
    }
}
