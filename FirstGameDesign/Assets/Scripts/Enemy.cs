using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    [HideInInspector]
    public Transform player;
    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int pickupChance;
    public GameObject[] pickups;

    public int healthPickupChance;
    public GameObject hearth;
    public GameObject deathMark;
    public GameObject Explosion;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0) {
            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickupChance && GameObject.FindGameObjectsWithTag("NewWeapon").Length < 1) {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                randomPickup.tag = "NewWeapon";
                randomPickup.layer = 12;
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            int randomHealthPickupNumber = Random.Range(0, 101);
            if (randomHealthPickupNumber < healthPickupChance)
            {
                Instantiate(hearth, transform.position, transform.rotation);
            }
            Instantiate(deathMark, transform.position, transform.rotation);
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
