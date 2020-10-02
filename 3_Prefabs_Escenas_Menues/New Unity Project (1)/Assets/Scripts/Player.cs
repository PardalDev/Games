using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 moveAmount;
    public int speed;
    public GameObject Joy;
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
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

}
