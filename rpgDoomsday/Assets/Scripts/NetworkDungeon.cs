using Photon.Pun;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkDungeon : MonoBehaviourPunCallbacks
{
    public bool singlePlayer = true;
    public Transform camera;
    public Canvas myCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PhotonNetwork.IsConnected)
        {
            singlePlayer = false;
        
            if (PhotonNetwork.CurrentRoom.PlayerCount != 1)
            {
                GameObject myPlayer = PhotonNetwork.Instantiate(Path.Combine("Player"), new Vector3(30.01f, 0f, 31.94f), Quaternion.identity);
                myPlayer.GetComponent<Hero>().canvas = myCanvas;
                Transform myPlayerTransform = myPlayer.transform;
                camera.GetComponent<CameraController>().SetTarget(myPlayerTransform);
            }
        }
        else
        {
            PhotonNetwork.OfflineMode = true;
            PhotonNetwork.CreateRoom("SingleRoom");
        }
    }


    // Update is called once per frame

}
