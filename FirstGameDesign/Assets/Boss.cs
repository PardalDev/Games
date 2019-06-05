using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;
    private int halfHealth;
    private Animator anim;

    private Slider bar;

    public int damage;
    private SceneTransition scene;

    public void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        bar = FindObjectOfType<Slider>();
        bar.maxValue = health;
        bar.value = health;
        scene = FindObjectOfType<SceneTransition>();
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        bar.value = health;
        //    UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            bar.gameObject.SetActive(false);
            scene.LoadScene("win");
        }
        if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }
        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset,0),transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            collision.GetComponent<Player>().takeDamage(damage);
        }
    }
}
