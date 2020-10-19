using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button SinglePlay = null;
    [SerializeField] private Button NetworkPlay = null;
    [SerializeField] private Button MultiplayerPlay = null;

    private const string PlayerPrefsNameKey = "PlayerName";

    private void Start()
    {
        SetUpInputField();
    }

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) {return; }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);
        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }

    //Solo podes apretar el start si el nombre existe
    public void SetPlayerName(string name)
    {
        SinglePlay.interactable = !string.IsNullOrEmpty(nameInputField.text);
        NetworkPlay.interactable = !string.IsNullOrEmpty(nameInputField.text);
        MultiplayerPlay.interactable = !string.IsNullOrEmpty(nameInputField.text);
    }

    public void SavePlayerName() {
        string playerName = nameInputField.text;
        PhotonNetwork.NickName = playerName;
        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
    }
}
