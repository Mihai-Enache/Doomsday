using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public LoadingScreenControl loadingScreenControl;
    public RoomListingMenu roomMenu;
    public InputField roomNameInput;
    public InputField maxPlayersInput;
    public string roomName;
    public int maxPlayers;
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby();
        //PhotonNetwork.JoinOrCreateRoom("TrialRoom", roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room ");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room ");
        loadingScreenControl.LoadScreenExample(1);
        //CreatePlayer();
    }

    public void RoomCreate()
    {
        Debug.Log("Trying to create room...");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)maxPlayers;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }
    public void RoomJoin()
    {
        Debug.Log("Trying to join room...");
        PhotonNetwork.JoinRoom(roomName);
    }
    public void UpdateRoomName()
    {

        roomName = roomNameInput.text;
        Debug.Log(roomName);
    }
    public void DisconnectFunc()
    {
        roomMenu.EliminateList();
        PhotonNetwork.Disconnect();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected " + cause);
    }
    public void UpdateMaxPlayers()
    {   
        maxPlayers = int.Parse(maxPlayersInput.text);
        Debug.Log(maxPlayersInput.text);
    }
}