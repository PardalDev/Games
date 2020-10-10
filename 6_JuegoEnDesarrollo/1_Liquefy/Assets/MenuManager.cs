using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class MenuManager : MonoBehaviourPunCallbacks
{
    public InputField playerName;
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        //playButton.interactable = false;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Update is called once per frame
    public void Play()
    {
        string playerNameText = playerName.text;
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.NickName = playerName.text;
        string roomName = "Room" + Random.Range(0, 1000);
        PhotonNetwork.CreateRoom(roomName,roomOptions);

    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }



}
