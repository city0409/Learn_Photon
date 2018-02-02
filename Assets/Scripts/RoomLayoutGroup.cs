using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayoutGroup : MonoBehaviour 
{
    [SerializeField]
    private GameObject roomListingPrefab;
    public GameObject RoomListingPrefab { get { return roomListingPrefab; } }

    private List<RoomListing> roomListingButtons = new List<RoomListing>();
    public List<RoomListing> RoomListingButtons { get { return roomListingButtons; } }

    //Invoke by Photon
    private void OnReceivedRoomListUpdate() 
	{
        DebugManager.Instance.Print("OnReceivedRoomListUpdate");

        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        foreach (RoomInfo info in rooms)
        {
            RoomReceived(info);
        }
	}
	
	private void RoomReceived(RoomInfo info) 
	{
        if (RoomListingButtons.Find(x => x.name == info.Name)) return;

        if (info .IsVisible  && info .PlayerCount <info .MaxPlayers )
        {
            GameObject roomListingOBJ = Instantiate(RoomListingPrefab);
            roomListingOBJ.transform.SetParent(transform, false);
            RoomListing roomListing = roomListingOBJ.GetComponent<RoomListing>();
            RoomListingButtons.Add(roomListing);
            roomListing.SetRoomName(info.Name);
        }
        
    }
}
