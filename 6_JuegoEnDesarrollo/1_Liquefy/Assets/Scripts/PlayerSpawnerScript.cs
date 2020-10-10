using Photon.Pun;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject spawnPoint = null;
    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
