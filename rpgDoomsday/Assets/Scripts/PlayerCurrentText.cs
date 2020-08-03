using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrentText : MonoBehaviour
{
    public Text Score_UIText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject object1 = GameObject.Find("MouseManager");
        int playerNumber = object1.GetComponent<MouseManager>().player;
        int resources;
        if (playerNumber == 1)
        {;
            resources = object1.GetComponent<MouseManager>().player1.GetComponent<PlayerScript1>().resources;
        }
        else
        {
            resources = object1.GetComponent<MouseManager>().player2.GetComponent<PlayerScript2>().resources;
        }
        //change color
        if (playerNumber == 1)
            Score_UIText.color = Color.blue;
        else
            Score_UIText.color = Color.green;
        string playerText = "Player " + playerNumber.ToString() + "\nResources: " + resources.ToString();
        Score_UIText.text = playerText;
    }
}
