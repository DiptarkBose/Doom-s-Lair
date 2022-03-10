using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject TrapGameObject;

    private void OnTriggerEnter(Collider other)
    {
        TriggerTrap();
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerTrap();
    }

    private void TriggerTrap()
    {
        ITrapInterface trapInterface = TrapGameObject.GetComponent(typeof(ITrapInterface)) as ITrapInterface;
        if (trapInterface != null)
        {
            trapInterface.TriggerTrap();
        }
        else
        {
            Debug.Log("Did not find object that implements trap interface");
        }
    }
}
