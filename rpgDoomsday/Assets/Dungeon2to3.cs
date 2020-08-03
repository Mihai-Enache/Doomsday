using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon2to3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Opened Door!");
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene("Dungeon3");
    }
}
