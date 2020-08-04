using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon2to1 : MonoBehaviour
{
    public LoadingScreenControl lsc;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Opened Door!");
        if (other.gameObject.tag == "Player")
            //SceneManager.LoadScene("Dungeon");
            lsc.LoadScreenExample(1);
    }
}
