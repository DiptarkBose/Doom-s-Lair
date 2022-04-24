using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAttack : MonoBehaviour
{

    [SerializeField] private Animator anim;
     void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Player"));
          {
             anim.SetBool("kick1", true);
         }
     }
     void OnTriggerExit(Collider other)
     {
         if (other.gameObject.CompareTag("Player"));
          {
              anim.SetBool("kick1", false);
         }
     }
}
