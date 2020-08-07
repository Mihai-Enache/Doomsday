using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListingUpdate : MonoBehaviour
{
    public Text name;
    public Text players;
    public RoomInfo info;

    public void SetRoomInfo (RoomInfo roomInfo)
    {
        info = roomInfo;
        name.text = roomInfo.Name;
        
        players.text = roomInfo.PlayerCount.ToString() + "/" + roomInfo.MaxPlayers.ToString();

    }
}
