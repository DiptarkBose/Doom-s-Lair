using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDartTrap : MonoBehaviour, ITrapInterface
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ITrapInterface.TriggerTrap()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        FindObjectOfType<AudioManager>().Play("Dart");
        foreach (Transform child in allChildren)
        {
            DartSpawner dartSpawner = child.gameObject.GetComponent<DartSpawner>();
            if (dartSpawner)
            {
                dartSpawner.FireProjectile();
            }
        }
    }
}
