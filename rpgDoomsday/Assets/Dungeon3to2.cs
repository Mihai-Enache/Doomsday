using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon3to2 : MonoBehaviour
{ 
    public LoadingScreenControl lsc;

    private void OnTriggerEnter(Collider other)
    {
       
        //Debug.Log("Opened Door!");
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(2);
            //lsc.LoadScreenExample(2);
    }
}
