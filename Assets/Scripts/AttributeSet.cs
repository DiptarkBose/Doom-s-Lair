using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSet : MonoBehaviour
{
    // All possible attributes any type of GameObject (Players, enemies, traps, etc.) can have.
    // For the sake of consistency, please make them all floats and cast them later if need be.
    // If an attribute is not used by a GameObject, it should be set to -1;
    public float Health;
    public float KeyPieceCount;
    public float WitchHealth;

}
