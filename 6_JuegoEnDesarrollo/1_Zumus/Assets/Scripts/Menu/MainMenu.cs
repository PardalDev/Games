using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private Button ButtonStart = null;
    [SerializeField] private TextMeshProUGUI waitingStatusText = null;

    private bool isConnecting = false;

    private const string GameVersion = "0.1";
    private const int MinPlayersPerRoom = 2;
    private const int MaxPlayersPerRoom = 10;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void FindOpponents()
    {
        isConnecting = true;
        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);
        waitingStatusText.text = "Searching...";

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else {
            PhotonNetwork.GameVersion= GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        if (isConnecting) {
            PhotonNetwork.JoinRandomRoom();
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);
        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No clients waiting for an opponent, creating new room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully joined to a room");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount != MaxPlayersPerRoom)
        {
            waitingStatusText.text = "Waiting for opponents " +
                "Current Player count: "+ PhotonNetwork.CurrentRoom.PlayerCount;
            Debug.Log("Client is waiting for opponents");
        }
        else {
            waitingStatusText.text = "Opponent Found";
            Debug.Log("Maching ready to begin");
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= MinPlayersPerRoom)
        {
            waitingStatusText.text = "You joined a match";
            Debug.Log("Match is ready to begin");
            ButtonStart.interactable=true;
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom) {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            waitingStatusText.text = "You joined a match";
            Debug.Log("Match is ready to begin");
            PhotonNetwork.LoadLevel("GameLevel");
        }
    }
    public void LunchGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= MinPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            waitingStatusText.text = "You joined a match";
            Debug.Log("Match is ready to begin");
            PhotonNetwork.LoadLevel("GameLevel");
        }
    }

    public void LoadLevelNet()
    {
            PhotonNetwork.LoadLevel("GameLevelNetwork");
    }

} 
