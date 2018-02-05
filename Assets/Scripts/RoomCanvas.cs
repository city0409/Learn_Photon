using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvas : MonoBehaviour 
{

	public void OnClick_StartDelay() 
	{
        PhotonNetwork.LoadLevel(1);
    }

    public void OnClick_StartSync () 
	{
        PhotonNetwork.LoadLevel(1);
	}
}
