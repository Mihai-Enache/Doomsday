using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public GameObject[] players;
    public Rigidbody rb;
    public GameObject target;
    public float fireballDamage = 20f;

    private float delay = 3.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectsWithTag("Player");
        target = Helpers.GetClosestPlayer(transform, players);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        rb.AddForce(dir * 700.0f);
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Unit>().TakeDamage(fireballDamage);
            Destroy(gameObject);
        }
    }
}
