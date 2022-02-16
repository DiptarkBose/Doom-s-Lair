using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleEnemyAttack : MonoBehaviour
{
    public GameObject player;
    private Animation anim;
    public GameObject enemy;
    private bool aggravated = false;
    private Vector3 originalPose;
    private float maxAggroDist = 100f;
    // Start is called before the first frame update
    void Start()
    {
        originalPose = enemy.transform.position;
        anim = gameObject.GetComponent<Animation>();
        anim["Spin"].speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 10f)
            {
                aggravated = true;
                anim["Spin"].speed = 1f;
            }
            else
            {
                anim["Spin"].speed = 0f;
            }
    }
}
