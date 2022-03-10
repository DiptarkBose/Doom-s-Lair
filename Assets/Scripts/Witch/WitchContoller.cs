using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WitchContoller : MonoBehaviour
{
    public GameObject player;
    private Animation anim;
    public GameObject witch;
    private bool aggravated = false;
    private Vector3 originalPose;
    private float maxAggroDist = 100f;

     public AttributeSet attributeSet;
    NavMeshAgent navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPose = witch.transform.position;
        anim = gameObject.GetComponent<Animation>();
        anim["Spin"].speed = 0f;
        attributeSet = gameObject.GetComponentInParent<AttributeSet>();

        if (navMeshAgent == null)
        {
            Debug.Log("NavMeshAgent Componet Missing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 10f)
        {
            aggravated = true;
            float step = .2f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(navMeshAgent.transform.forward, player.position, step, 0.0f);
            navMeshAgent.transform.rotation = Quaternion.LookRotation(newDir);
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            anim["Spin"].speed = 0f;
            navMeshAgent.enabled = false;
        }
    }
}
