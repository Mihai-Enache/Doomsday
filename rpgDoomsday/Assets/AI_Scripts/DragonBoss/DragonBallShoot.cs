using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBallShoot : MonoBehaviour
{
    public GameObject[] players;
    public Rigidbody rb;
    public GameObject target;
    public float dragonballDamage = 50f;

    private float delay = 3.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectsWithTag("Player");
        target = Helpers.GetClosestPlayer(transform, players);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        rb.AddForce(dir * 900.0f);
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Unit>().TakeDamage(dragonballDamage);
            Destroy(gameObject);
        }
    }
}