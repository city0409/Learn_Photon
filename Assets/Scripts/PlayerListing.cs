using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviour 
{
    public PhotonPlayer PhotonPlayer { get; private set; }
    [SerializeField]
    private Text playerText;
    public Text PlayerText { get { return playerText; } }


    public void ApplyPhotonPlayer(PhotonPlayer player) 
	{
        PlayerText.text = player.NickName;
        PhotonPlayer = player;
	}

}
