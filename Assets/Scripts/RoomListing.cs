using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour 
{
    [SerializeField]
    private Text roomNameText;
    public Text RoomNameText { get { return roomNameText; } }

    public string RoomName { get; private set; }


    private void Awake() 
	{
		
	}
	
	public  void SetRoomName(string text) 
	{
        RoomName = text;
        RoomNameText.text = RoomName;
	}
}
