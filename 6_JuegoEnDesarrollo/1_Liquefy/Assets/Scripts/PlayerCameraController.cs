using Cinemachine;
using Photon.Pun;
using UnityEngine;



public class PlayerCameraController : MonoBehaviourPun
{

    [Header("Camera")]
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

    private CinemachineTransposer transposer;

    //Este metodo habilita a que cada uno que tenga autoridad sobre sus atributos pueda encender la camara.

    private void Start()
    {
        if (photonView.IsMine)
        {
            transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            virtualCamera.gameObject.SetActive(true);
            //Enciendo la camara del player local.
            enabled = true;
        }
    }



}
