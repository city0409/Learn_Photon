﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetwork : MonoBehaviour 
{

	private void Start() 
	{
        DebugManager.Instance.Print("connect to servers");
        PhotonNetwork.ConnectUsingSettings("Version:0.0.1");
	}
	
	private void OnConnectedToMaster () 
	{
        DebugManager.Instance.Print("connect to Master");
        PhotonNetwork.automaticallySyncScene = false;
        PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void  OnJoinedLobby()
    {
        DebugManager.Instance.Print("On joined lobby.");
    }
}
