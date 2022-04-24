using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonitorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    AttributeSet attributeSet;
    AudioSource audioSource;
    float curHealth, curArmor;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        attributeSet = player.GetComponent<PlayerController>().GetComponent<AttributeSet>();
        curHealth = (float)attributeSet.GetType().GetField("Health").GetValue(attributeSet);
        curArmor = (float)attributeSet.GetType().GetField("Armor").GetValue(attributeSet);
    }

    // Update is called once per frame
    void Update()
    {
        float newHealth = (float)attributeSet.GetType().GetField("Health").GetValue(attributeSet);
        float newArmor = (float)attributeSet.GetType().GetField("Armor").GetValue(attributeSet);
        if (newHealth < curHealth || newArmor < curArmor)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        curHealth = newHealth;
        curArmor = newArmor;
    }
}
