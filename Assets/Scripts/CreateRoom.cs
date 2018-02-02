using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateRoom : MonoBehaviour 
{
    [SerializeField]
    private Text roomName;
    public Text RoomName { get { return roomName; } }


    public  void OnClick_CreateRoom() 
	{
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        if (PhotonNetwork .CreateRoom (RoomName .text,roomOptions,TypedLobby.Default  ))
        {
            DebugManager.Instance.Print("Create room successfully send");
        }
        else
        {
            DebugManager.Instance.Print("Create room failed to send");
        }
	}
	
	private void OnCreatedRoom () 
	{
        DebugManager.Instance.Print("Room Created");
	}
}
