using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBallShoot : MonoBehaviour
{
    public GameObject towerballPrefab;
    private GameObject[] players;
    public GameObject firePoint1, firePoint2, firePoint3, firePoint4;
    private float delay = 2.0f;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        InvokeRepeating("LaunchProjectiles", 2.0f, 2.0f);
    }

    void LaunchProjectiles()
    {
        GameObject distance = Helpers.GetClosestPlayer(transform, players);

        if (Vector3.Distance(this.transform.position, distance.transform.position) < 40f)
        {
            GameObject towershot1, towershot2, towershot3, towershot4;
            towershot1 = Instantiate(towerballPrefab, firePoint1.transform.position, Quaternion.identity);
            towershot2 = Instantiate(towerballPrefab, firePoint2.transform.position, Quaternion.identity);
            towershot3 = Instantiate(towerballPrefab, firePoint3.transform.position, Quaternion.identity);
            towershot4 = Instantiate(towerballPrefab, firePoint4.transform.position, Quaternion.identity);
            towershot1.GetComponent<Rigidbody>().AddForce(-transform.forward * 400f);
            towershot2.GetComponent<Rigidbody>().AddForce(transform.forward * 400f);
            towershot3.GetComponent<Rigidbody>().AddForce(transform.right * 400f);
            towershot4.GetComponent<Rigidbody>().AddForce(-transform.right * 400f);
            Destroy(towershot1, delay);
            Destroy(towershot2, delay);
            Destroy(towershot3, delay);
            Destroy(towershot4, delay);
        }
    }
}
