using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAITest : MonoBehaviour
{
    public float m_MoveSpeed = 10.0f;
    //public CharacterState m_CharacterState;

    protected float m_Move;
    protected float m_Strafe;
    public bool m_IsDead;
    public bool m_IsAttacking;

    protected Animator anim;

    private Collider[] m_AllColliders;

    // Use this for initialization
    virtual protected void Start()
    {
        anim = GetComponent<Animator>();
        m_IsDead = false;
        m_IsAttacking = false;

        m_AllColliders = this.GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame (leave this for parent classes to populate)
    virtual protected void Update()
    {
        
    }

    // clear all animations
    protected void ClearAnim()
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isDead", false);
    }

    // char attack
    protected void Attack()
    {
        m_IsAttacking = true;
        ClearAnim();
        anim.SetBool("isAttacking", true);
        StartCoroutine(ReenableAttacking());
    }

    protected IEnumerator ReenableAttacking()
    {
        yield return new WaitForSeconds(3.0f);
        m_IsAttacking = false;
    }

    // kill and cleanup enemy
    protected void MakeDead()
    {
        ClearAnim();
        anim.SetBool("isDead", true);

        // disable all colliders
        foreach (Collider c in m_AllColliders)
        {
            c.enabled = false;
        }
        m_IsDead = true;
    }
}
