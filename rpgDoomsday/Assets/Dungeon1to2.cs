using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon1to2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Opened Door!");
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene("Dungeon2");
    }
}
