using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    public RoomListingUpdate roomListingObject;
    public Transform content;

    private List<RoomListingUpdate> listings = new List<RoomListingUpdate>();

    public override void OnRoomListUpdate (List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.info.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else
            {
                RoomListingUpdate listing = Instantiate(roomListingObject, content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    listings.Add(listing);
                }
            }
        }
    }
    public void EliminateList()
    {
        foreach (RoomListingUpdate room in listings)
        {
            int index = listings.FindIndex(x => x);
            Destroy(listings[index].gameObject);
        }
        Debug.Log("Eliminated");
        listings.Clear();
    }
}
