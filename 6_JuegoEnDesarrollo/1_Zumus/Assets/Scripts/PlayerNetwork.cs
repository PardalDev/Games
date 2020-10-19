using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerNetwork : NetworkBehaviour
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

        Vector2 moveImput = new Vector2(Input.GetAxisRaw("Horizontal") + joystick.Horizontal, Input.GetAxisRaw("Vertical") + joystick.Vertical);
        moveAmount = moveImput.normalized * speed;

        if (moveImput != Vector2.zero)
        {

            if (Input.GetKeyDown("left shift"))
            {
                //   
            }
            else
            {
                //
            }
        }
        else
        {
            //
        }


    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
            rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

}
