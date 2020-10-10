using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Player : NetworkBehaviour
{
    private Vector2 moveAmount;
    public int speed;
    protected Joystick joystick;
    protected Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        if (!hasAuthority)
            return;

        Vector2 moveImput = new Vector2(Input.GetAxisRaw("Horizontal") + joystick.Horizontal, Input.GetAxisRaw("Vertical") + joystick.Vertical);
        moveAmount = moveImput.normalized * speed;

    }

    private void FixedUpdate()
    {
        //El cliente que tiene autoridad para moverse, le pide al server que le permita moverse
        if (isLocalPlayer && hasAuthority)
            CmdMove();
    
    }

    //Los clientes le piden al server moverse
    [Command]
    private void CmdMove() {
        ClientMoveOrder();
    }

    //El server le dice a los clientes que se deben mover
    [ClientRpc]
    private void ClientMoveOrder() {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
}
