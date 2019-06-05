using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public GameObject explode;
    public GameObject sound;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProyectile", lifeTime);
        Instantiate(sound, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            collision.GetComponent<Enemy>().takeDamage(damage);
            DestroyProyectile();
        }
        if (collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().takeDamage(damage);
            DestroyProyectile();
        }
    }


    void DestroyProyectile() {
        Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
