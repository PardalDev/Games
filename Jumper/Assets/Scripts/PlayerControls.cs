using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    protected Joystick joystick;
    protected joybutton joybutton;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    private GameOverScript GameOver;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inicio sin velocidad en ninguno de los dos ejes
        //rb.velocity = new Vector2(0, rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        rb.velocity = new Vector2(joystick.Horizontal * 5f + Input.GetAxis("Horizontal") * 5f, rb.velocity.y);
        if (rb.velocity.x > 0) {
            GetComponent<Animator>().SetBool("Corriendo", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (rb.velocity.x == 0)
        {
            GetComponent<Animator>().SetBool("Corriendo", false);
        }
        if (rb.velocity.x < 0)
        {
            GetComponent<Animator>().SetBool("Corriendo", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        /*
        // Para moverse con A y D
        if (Input.GetKey(KeyCode.D)) {
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            GetComponent<Animator>().SetBool("Corriendo", true);
            transform.Translate(0.09f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            GetComponent<Animator>().SetBool("Corriendo", true);
            transform.Translate(-0.09f, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
            GetComponent<Animator>().SetBool("Corriendo", false);
        }
        */

        //Si clickeo y estoy en tierra salto!
        if ((joybutton.Pressed & onGround) || (Input.GetKey(KeyCode.K) & onGround))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
        //ademas si clickeo disparo
        bool shoot = false;
        if ((joybutton.Pressed) || (Input.GetKey(KeyCode.L)))
        {
            shoot = true;
        }

        if (shoot) {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null) {
                //El player es quien ataca por eso envio false (se espera isEnemy en el weapon script)
                weapon.Attack(false);
                //Se migra el efecto para el arma en vez de que lo reproduzca el usuario, de esta forma no sonara cada vez que se apreta el boton, sino cuando el CD lo permite
                //SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
        }

        //---------------------------------------------------------------------------------
        // 6 - Esto no esta en uso, pero es para controlar que siempre estes dentro de la camara 
        //(al dope en este caso porque la camara sigue al personaje....pero podria no hacerlo)
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;
        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;
        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
        //---------------------------------------------------------------------------------
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Collision with enemy
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Kill the enemy
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

            damagePlayer = true;
        }

        // Damage the player
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }
     void OnDestroy()
     {
         // Game Over.
         var GameOver = FindObjectOfType<GameOverScript>();
         GameOver.ShowButtons();
     }
}
