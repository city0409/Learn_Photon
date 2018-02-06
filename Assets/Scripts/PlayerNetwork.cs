using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour 
{
    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    private PhotonView photonView;

    private int playerCount;

    private void Awake() 
	{
        Instance = this;
        photonView = GetComponent<PhotonView>();
        PlayerName = "Player" + Random.Range(0, 9999);

        SceneManager.sceneLoaded += OnSceneFinishedLoaded;

    }

    private void OnSceneFinishedLoaded(Scene scene,LoadSceneMode mode)
    {
        if (scene .name == "Game")
        {
            if (PhotonNetwork .isMasterClient )
            {
                MasterLoadedGame();
            }
            else
            {
                NonMasterLoadedGame();
            }
        }
    }

    private void MasterLoadedGame()
    {
        photonView.RPC("RPC_LoadGameScene", PhotonTargets.MasterClient);
        photonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }

    private void NonMasterLoadedGame()
    {
        photonView.RPC("RPC_LoadGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameScene()
    {
        playerCount++;
        if (playerCount==PhotonNetwork .playerList .Length )
        {
            photonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(1);
    }

    [PunRPC]
    private void RPC_CreatePlayer()
    {
        PhotonNetwork.Instantiate("Prefabs/Player",Vector3.zero,Quaternion.identity,0);
    }

}
