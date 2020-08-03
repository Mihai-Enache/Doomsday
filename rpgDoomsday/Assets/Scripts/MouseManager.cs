using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    GameObject hitObject;
    GameObject oldObject;
    GameObject oldDestObject;
    public int turnCount = 0;
    public GameObject player1, player2;
    public int player = 1;
    int player1Ship = 0;
    int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("b"))
        {
            
            if (player == 1)
            {
                player1.GetComponent<PlayerScript1>().building = 1;

            }
            else
            {
                player2.GetComponent<PlayerScript2>().building = 1;

            }
        }
        if (Input.GetKeyDown("c"))
        {
            if (player == 1)
            {
                player1.GetComponent<PlayerScript1>().building = 0; ;
            }
            else
            {
                player2.GetComponent<PlayerScript2>().building = 0;

            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player == 1)
            {
                player1.GetComponent<PlayerScript1>().turnCount++;
                player = 2;
            }
            else
            {
                player = 1;
                player2.GetComponent<PlayerScript2>().turnCount++;
            }

        }
        if (oldDestObject)
        {
            if (frameCounter == 0)
            {
                MeshRenderer mesh = oldDestObject.GetComponentInChildren<MeshRenderer>();
                mesh.material.color = Color.white;
                oldDestObject = null;
            }
            else
            {
                frameCounter--;
            }
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            
            GameObject hitObject = hitInfo.collider.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                if (oldObject)
                {
                    MeshRenderer oldMesh = oldObject.GetComponentInChildren<MeshRenderer>();
                    if(oldMesh.material.color != Color.gray)
                        oldMesh.material.color = Color.white;
                    if(player1Ship == 1)
                    {
                        oldMesh.material.color = Color.gray;
                        player1Ship = 0;
                    }
                    if (player == 1)
                        player1.GetComponent<PlayerScript1>().Selected = null;
                    else
                        player2.GetComponent<PlayerScript2>().Selected = null;
                }
                if (hitObject != oldObject)
                {
                    if (hitObject.name == "Hexagon")
                    {
                        
                       // MeshRenderer mesh = hitObject.GetComponentInChildren<MeshRenderer>();
                       // mesh.material.color = Color.red;
                        oldObject = hitObject;
                        if(player == 1)
                            if (player1.GetComponent<PlayerScript1>().building == 0)
                                player1.GetComponent<PlayerScript1>().Selected = hitObject;
                            else
                                player1.GetComponent<PlayerScript1>().BuildShip(hitObject);
                        else
                            if (player2.GetComponent<PlayerScript2>().building == 0)
                                player2.GetComponent<PlayerScript2>().Selected = hitObject;
                            else
                                player2.GetComponent<PlayerScript2>().BuildShip(hitObject);


                    }
                    if (hitObject.name == "Ship")
                    {
                        if (hitObject.transform.parent.gameObject.GetComponent<ShipScript>().owner == player)
                        {
                            GameObject ship = hitObject.transform.parent.gameObject;

                            MeshRenderer mesh = hitObject.GetComponentInChildren<MeshRenderer>();
                            if (player == 1)
                            {
                                if (ship.GetComponent<ShipScript>().owner == 1)
                                {
                                    player1Ship = 1;
                                    mesh.material.color = Color.blue;
                                }
                            }
                            else
                            {
                                if (ship.GetComponent<ShipScript>().owner == 2)
                                    mesh.material.color = Color.green;
                            }
                            oldObject = hitObject;
                            if (player == 1)
                                player1.GetComponent<PlayerScript1>().Selected = hitObject;
                            else
                                player2.GetComponent<PlayerScript2>().Selected = hitObject;
                        }
                    }
                }
                else
                {
                    oldObject = null;    
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (player == 1)
                {
                    if (player1.GetComponent<PlayerScript1>().Selected.name == "Ship")
                    {
                        Debug.Log(player1.GetComponent<PlayerScript1>().Selected.transform.parent.gameObject.name);
                        if (hitObject.name == "Hexagon")
                        {
                            // float xDest = 2f; //hitObject.GetComponent<HexScript>.xPractical;
                            //float yDest = 2f; //hitObject.GetComponent<HexScript>.yPractical;
                            //player1.GetComponent<PlayerScript1>().Mothership.GetComponent<ShipScript>().Move(hitObject);
                            Debug.Log(player1.GetComponent<PlayerScript1>().Selected.name);
                            player1.GetComponent<PlayerScript1>().Selected.transform.parent.gameObject.GetComponent<ShipScript>().Move(hitObject);
                            MeshRenderer mesh = hitObject.GetComponentInChildren<MeshRenderer>();
                            mesh.material.color = Color.blue;
                            oldDestObject = hitObject;
                            frameCounter = 15;
                        }
                    }
                }

                if (player == 2)
                {
                    if (player2.GetComponent<PlayerScript2>().Selected.name == "Ship")
                    {
                        if (hitObject.name == "Hexagon")
                        {
                            //float xDest = 2f; //hitObject.GetComponent<HexScript>.xPractical;
                            //float yDest = 2f; //hitObject.GetComponent<HexScript>.yPractical;
                            player2.GetComponent<PlayerScript2>().Selected.transform.parent.gameObject.GetComponent<ShipScript>().Move(hitObject);
                            MeshRenderer mesh = hitObject.GetComponentInChildren<MeshRenderer>();
                            mesh.material.color = Color.green;
                            oldDestObject = hitObject;
                            frameCounter = 15;
                        }
                    }
                }
            }
        }
        
    }
}
