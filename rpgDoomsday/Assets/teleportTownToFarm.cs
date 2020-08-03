using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportTownToFarm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Opened Door!");
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene("FarmArea");
    }
}
