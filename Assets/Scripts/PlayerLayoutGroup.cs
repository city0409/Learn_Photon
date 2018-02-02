using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayoutGroup : MonoBehaviour 
{
    //Invoke by Photon
	private void OnJoinedRoom() 
	{
        DebugManager.Instance.Print("On Joined Room");
	}
}
