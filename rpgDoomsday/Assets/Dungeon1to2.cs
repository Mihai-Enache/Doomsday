using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon1to2 : MonoBehaviour
{ 
    public LoadingScreenControl lsc;
    private void OnTriggerEnter(Collider other)
    {
       
        //Debug.Log("Opened Door!");
        if (other.gameObject.tag == "Player")
           SceneManager.LoadScene(2);
           //lsc.LoadScreenExample(2);
           //LoadingScreenControl.instance.LoadScreenExample(2);

    }
}
