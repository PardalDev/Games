using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Mirror;

public class PlayerCameraController : NetworkBehaviour
{

    [Header("Camera")]
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

    private CinemachineTransposer transposer;

    //Este metodo habilita a que cada uno que tenga autoridad sobre sus atributos pueda encender la camara.
    public override void OnStartAuthority()
    {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        virtualCamera.gameObject.SetActive(true);
        //Enciendo la camara del player local.
        enabled = true;
    }



}
