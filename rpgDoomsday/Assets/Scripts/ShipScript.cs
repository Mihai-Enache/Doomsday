using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public int owner;
    public int xTheoretical = 0;
    public int yTheoretical = 0;
    public float xPractical = 0f;
    public float yPractical = 0f;
    public GameObject HexPrefab = null;
    public float xDest = 0f;
    public float yDest = 0f;
    public int moved = 0;

    public int Health = 100;
    public int Damage = 40;

    Vector3 Destination;


    // Start is called before the first frame update
    void Start()
    {
        Destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Destination != transform.position)
        {
            Vector3 Dist = Destination - transform.position;
            Vector3 Speed = Dist.normalized * Time.deltaTime;

            Speed = Vector3.ClampMagnitude(Speed, Dist.magnitude);
            transform.Translate(Speed);
        }
    }

    public void Move(GameObject HexNew)
    {
        if (moved == 0)
        {

            if (HexNew.transform.parent.gameObject.GetComponent<HexScript>().occupied == 0)
            {
                HexPrefab.GetComponent<HexScript>().occupied = 0;
                HexPrefab = HexNew.transform.parent.gameObject;
                Debug.Log("Moving... I guess");
                //Destination = Dest;
                //Destination[0] = xDestination;
                //Destination[2] = yDestination;
                Destination = HexNew.transform.position;

                moved = 1;
                HexPrefab.GetComponent<HexScript>().occupied = 1;
            }
        }
    }
    public int Gather()
    {
        int res = HexPrefab.GetComponent<HexScript>().resources / 8;
        HexPrefab.GetComponent<HexScript>().resources -= res;

        moved = 0;
        return res;
    }
}
