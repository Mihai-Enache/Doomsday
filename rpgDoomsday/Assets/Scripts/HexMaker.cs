using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMaker : MonoBehaviour

{
    public GameObject HexPrefab;
    // Start is called before the first frame update
    int Up = 14;
    int Right = 24;
    float UpOffset = 0.753f;
    float RightOffset = 0.87f;
    float RightOffsetOffrow = 0.0f;
    float xPos = 0f;
    float yPos = 0f;
    void Start()
    {
        
        for (int i = 0; i < Right; i++)
        {
            for (int j = 0; j < Up; j++)
            {
                if (j % 2 == 0)
                {
                    RightOffsetOffrow = RightOffset / 2f;
                }
                else
                {
                    RightOffsetOffrow = 0f;
                }
                xPos = i * RightOffset + RightOffsetOffrow;
                yPos = j * UpOffset;
                GameObject hex_go = (GameObject) Instantiate(HexPrefab, new Vector3(xPos, 0, yPos), Quaternion.identity);
                hex_go.name = "Hex_" + i + "_" + j;
                hex_go.GetComponent<HexScript>().xTheoretical = i;
                hex_go.GetComponent<HexScript>().yTheoretical = j;
                hex_go.GetComponent<HexScript>().xPractical = xPos;
                hex_go.GetComponent<HexScript>().yPractical = yPos;
                hex_go.GetComponent<HexScript>().resources = 1500;
                hex_go.transform.SetParent(this.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowNeighbors()
    {

    }
}
