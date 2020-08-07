using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossSpawn : MonoBehaviour
{

    public GameObject finalBossPrefab;
    public GameObject towerPrefab;
    public GameObject helpersPrefab;
    public GameObject gatePrefab;
    private Vector3 scaleChange;
    private bool done;

    private void Start()
    {
        scaleChange = new Vector3(0f, 0f, 2.5f);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !done)
        {
            done = true;
            Invoke("CloseGateBoss", 1f);
            Invoke("SpawnFinalBoss", 3.0f);
            Invoke("SpawnBossTowers", 15f);
            InvokeRepeating("SpawnBossHelpers", 40f, 12.5f);
            Invoke("SpawnHarderTower", 30f);
        }
    }

    void CloseGateBoss()
    {
        GameObject gate = Instantiate(gatePrefab, transform.position + new Vector3(0, 0.97f, 0), Quaternion.identity);
        gate.transform.Rotate(0, 90f, 0);
        gate.transform.localScale += scaleChange;
    }
    
    void SpawnFinalBoss()
    {
        Instantiate(finalBossPrefab, transform.position + new Vector3(0, 1, 40), Quaternion.identity);
    }

    void SpawnBossTowers()
    {
        Instantiate(towerPrefab, transform.position + new Vector3(18, 1, 40), Quaternion.identity);
        Instantiate(towerPrefab, transform.position + new Vector3(-18, 1, 40), Quaternion.identity);
        Instantiate(towerPrefab, transform.position + new Vector3(18, 1, 10), Quaternion.identity);
        Instantiate(towerPrefab, transform.position + new Vector3(-18, 1, 10), Quaternion.identity);
    }

    void SpawnHarderTower()
    {
        Instantiate(towerPrefab, transform.position + new Vector3(0, 1, 27.5f), Quaternion.identity);
    }

    void SpawnBossHelpers()
    {
        Instantiate(helpersPrefab, transform.position + new Vector3(0, 1, 30f), Quaternion.identity);
    }
}
