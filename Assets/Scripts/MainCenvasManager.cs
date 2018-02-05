using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCenvasManager : MonoBehaviour 
{
    public static MainCenvasManager Instance;
    [SerializeField]
    private LobbyCanvas lobbyCanvas;
    public LobbyCanvas LobbyCanvas { get { return lobbyCanvas; } }
    [SerializeField]
    private RoomCanvas roomCanvas;
    public RoomCanvas RoomCanvas { get { return roomCanvas; } }

    private void Awake() 
	{
        Instance = this;
    }
}
