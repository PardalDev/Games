using UnityEngine;

public class PlayerLocal : MonoBehaviour
{
    private Vector2 moveAmount;
    public int speed;
    protected Joystick joystick;
    protected Rigidbody2D rb;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // if (!isLocalPlayer)
        //   return;

        Vector2 moveImput = new Vector2(Input.GetAxisRaw("Horizontal") + joystick.Horizontal, Input.GetAxisRaw("Vertical") + joystick.Vertical);
        moveAmount = moveImput.normalized * speed;

        //Chequeo si se esta moviendo
        if (moveImput != Vector2.zero)
        {

            if (Input.GetKeyDown("left shift"))
            {
                //anim.SetBool("isWalking", true);
                anim.SetBool("is_running", true);
            }
            else
            {
                //anim.SetBool("isWalking", true);
                anim.SetBool("is_running", true);
            }

        }
        else
        {
            //anim.SetBool("isWalking", false);
            anim.SetBool("is_running", false);
        }


    }

    private void FixedUpdate()
    {
            rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
            
    }
}
