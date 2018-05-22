using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public Rigidbody2D rb;
    public Vector2 speed = new Vector2(5,5);
    public Vector2 direction = new Vector2(-1, 0);
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool onGround;
    private MovementScript moveScript;
    private WeaponScript[] weapons;

    private bool hasSpawn;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;

    private void Awake()
    {
        moveScript = GetComponent<MovementScript>();
        weapons = GetComponentsInChildren<WeaponScript>();
        coliderComponent = GetComponent<Collider2D>();
        rendererComponent = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        hasSpawn = false;
        coliderComponent.enabled = true;

        moveScript.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update () {
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main)) {
                Spawn();
            }

            onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, 2);

            }
            else
            {
                direction = new Vector2(1, 0);
            }
        }
        else
        {
            onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.y, 2);
            }
            else
            {
                direction = new Vector2(0, 2);
            }

            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.CanAttack)
                {
                    //El enemigo es quien ataca...por eso envio true
                    weapon.Attack(true);
                    //Se migra el efecto para el arma en vez de que lo reproduzca el usuario, de esta forma no sonara cada vez que se apreta el boton, sino cuando el CD lo permite
                    //SoundEffectsHelper.Instance.MakeEnemyShotSound();
                }
            }

            if (rendererComponent.IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
	}
    private void Spawn()
    {
        hasSpawn = true;

        // -- Moving
        //moveScript.enabled = true;
        // -- Shooting
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
