using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawner : MonoBehaviour, ITrapInterface
{
    public GameObject projectile;
    public GameObject spawnLocation;
    public float launchVelocity = 700f;
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

    }

    public void FireProjectile()
    {
        GameObject dart = Instantiate(projectile, spawnLocation.transform.position, spawnLocation.transform.rotation);
        dart.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, -launchVelocity, 0));
    }
}
