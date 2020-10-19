using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    private Vector2 moveAmount;
    [SerializeField] public int speed;
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
        if (photonView.IsMine){
            TakeInput();        
        }
    }

    private void TakeInput()
    {
        Vector2 moveImput = new Vector2(Input.GetAxisRaw("Horizontal") + joystick.Horizontal, Input.GetAxisRaw("Vertical") + joystick.Vertical);
        moveAmount = moveImput.normalized * speed;
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
}
