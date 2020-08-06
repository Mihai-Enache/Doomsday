using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageHandler : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject fireballPrefab;
    public bool shootFB;
    
    void shootFireball()
    {
        shootFB = true;
    }
    

    private void Update()
    {
        if (shootFB)
        {
            Instantiate(fireballPrefab, firePoint.transform.position, Quaternion.identity);
            shootFB = false;
        }
    }
}
