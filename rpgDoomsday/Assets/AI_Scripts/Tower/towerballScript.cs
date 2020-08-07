using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerballScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Unit>().TakeDamage(10f);
            Destroy(gameObject);
        }
    }
}
