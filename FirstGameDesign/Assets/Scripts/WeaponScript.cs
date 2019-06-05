using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject proyectile;
    public Transform shotPoint;
    public float timeBetweenShots;
    private Enemy enemyScript;
    public int damage;

    public GameObject slash;

    private float shotTime;

    private Animator cameraAnim;
    // Update is called once per frame

    public void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
    }
    void Update()
    {
        if(gameObject.transform.root.gameObject.name == "Player") { 
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle -90,Vector3.forward);
            transform.rotation = rotation;

            //0 left mouse button
            if (Input.GetMouseButton(0)) {
                if (Time.time >= shotTime) {
                    Instantiate(proyectile, shotPoint.position, transform.rotation);
                    cameraAnim.SetTrigger("shake");
                    shotTime = Time.time + timeBetweenShots;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            Instantiate(slash, collision.gameObject.GetComponent<Transform>().position, collision.gameObject.GetComponent<Transform>().rotation);
            enemyScript.takeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            Instantiate(slash, collision.gameObject.GetComponent<Transform>().position, collision.gameObject.GetComponent<Transform>().rotation);
            enemyScript.takeDamage(damage);
        }
    }

}
