using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{
    public GameObject[] Ships;
    public int resources = 6000;
    public int shipsNr = 0;
    public GameObject ShipPrefab;
    public GameObject Selected;
    public GameObject Mothership;
    public int turnCount = 0;
    
    // Start is called before the first frame update
    int Right = 24 - 5;
    int Up = 7;
    float UpOffset = 0.753f;
    float RightOffset = 0.87f;
    float RightOffsetOffrow = 0.0f;
    float xPos = 0f;
    float yPos = 0f;
    public int building = 0;

    void Start()
    {
        Ships = new GameObject[16];
        for (int i = 0; i <= Right; i++)
        {
            for (int j = 0; j <= Up; j++)
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
            }
        }
        Mothership = (GameObject)Instantiate(ShipPrefab, new Vector3(xPos, 0.3f, yPos), Quaternion.identity);
        Mothership.GetComponent<ShipScript>().owner = 2;
        Mothership.GetComponent<ShipScript>().xTheoretical = Right;
        Mothership.GetComponent<ShipScript>().yTheoretical = Up;
        int xT = Mothership.GetComponent<ShipScript>().xTheoretical;
        int yT = Mothership.GetComponent<ShipScript>().yTheoretical;
        Mothership.GetComponent<ShipScript>().xPractical = xPos;
        Mothership.GetComponent<ShipScript>().yPractical = yPos;
        Mothership.GetComponent<ShipScript>().xDest = xPos;
        Mothership.GetComponent<ShipScript>().yDest = yPos;
        Mothership.GetComponent<ShipScript>().HexPrefab = GameObject.Find("Hex_" + xT + "_" + yT);
        Mothership.GetComponent<ShipScript>().HexPrefab.GetComponent<HexScript>().occupied = 1;

        resources += 6000;

    }

    // Update is called once per frame
    void Update()
    {
        if (turnCount > 0)
        {
            int res = Mothership.GetComponent<ShipScript>().Gather();
            for (int i = 0; i < shipsNr; i++)
            {
                //Debug.Log(Ships[shipsNr].name);
                res += Ships[i].GetComponent<ShipScript>().Gather();
            }
            resources += res;
            turnCount--;

        }

    }
    public void BuildShip(GameObject Hex)
    {
        if (resources >= 2000)
        {
            Debug.Log(Hex.transform.parent.gameObject.name);
            GameObject HexParent = Hex.transform.parent.gameObject;
            xPos = HexParent.GetComponent<HexScript>().xPractical;
            yPos = HexParent.GetComponent<HexScript>().yPractical;
            int xT = HexParent.GetComponent<HexScript>().xTheoretical;
            int yT = HexParent.GetComponent<HexScript>().yTheoretical;
            Ships[shipsNr] = (GameObject)Instantiate(ShipPrefab, new Vector3(xPos, 0.3f, yPos), Quaternion.identity);
            Ships[shipsNr].GetComponent<ShipScript>().owner = 2;
            Ships[shipsNr].GetComponent<ShipScript>().xTheoretical = xT;
            Ships[shipsNr].GetComponent<ShipScript>().yTheoretical = yT;
            Ships[shipsNr].GetComponent<ShipScript>().xPractical = xPos;
            Ships[shipsNr].GetComponent<ShipScript>().yPractical = yPos;
            Ships[shipsNr].GetComponent<ShipScript>().xDest = xPos;
            Ships[shipsNr].GetComponent<ShipScript>().yDest = yPos;
            Ships[shipsNr].GetComponent<ShipScript>().HexPrefab = GameObject.Find("Hex_" + xT + "_" + yT);
            Ships[shipsNr].GetComponent<ShipScript>().HexPrefab.GetComponent<HexScript>().occupied = 1;


            resources -= 2000;
            Debug.Log(Ships[shipsNr].name);
            shipsNr += 1;
        }
    }
}
