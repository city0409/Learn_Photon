using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayoutGroup : MonoBehaviour 
{
    [SerializeField]
    private GameObject playerListingPrefab;

    private List<PlayerListing> playerListings = new List<PlayerListing>();
    public List<PlayerListing> PlayerListings { get { return playerListings; } }


    //Invoke by Photon
    private void OnJoinedRoom() 
	{
        DebugManager.Instance.Print("On Joined Room");
        MainCenvasManager.Instance.RoomCanvas.transform.SetAsLastSibling();
        PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;

        for (int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
    }

    //Invoke by Photon
    private void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        PlayerJoinedRoom(newPlayer);
    }

    private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
    {
        if (photonPlayer == null) return;
        PlayerLeftRoom(photonPlayer);

        GameObject playerListingOBJ = Instantiate(playerListingPrefab);
        playerListingOBJ.transform.SetParent(this .transform, false);
        PlayerListing playerListing = playerListingOBJ.GetComponent<PlayerListing>();
        playerListing.ApplyPhotonPlayer(photonPlayer);
        PlayerListings.Add(playerListing);
    }

    private void PlayerLeftRoom(PhotonPlayer photonPlayer)
    {
        int index = playerListings.FindIndex(x => x.PhotonPlayer == photonPlayer);
        if (index != -1)
        {
            Destroy(PlayerListings[index].gameObject);
            PlayerListings.RemoveAt(index);
        }
    }

}
