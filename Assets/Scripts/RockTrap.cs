using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrap : MonoBehaviour, ITrapInterface
{
    void ITrapInterface.TriggerTrap()
    {
        gameObject.SetActive(false);
    }
}
