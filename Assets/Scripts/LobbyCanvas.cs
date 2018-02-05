using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour 
{

	private void Awake() 
	{
		
	}
	
	public  void OnClick_JoinRoom (string roomName) 
	{
        if (PhotonNetwork .JoinRoom (roomName ))
        {
            DebugManager.Instance.Print("join room successfully.");
        }
        else
        {
            DebugManager.Instance.Print("joined room failed.");
        }
    }
}
