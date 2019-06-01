using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;
    private Animator animator;
    public Transform shotPoint;

    public GameObject bullet;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            if (Time.time >= attackTime) {
                attackTime = Time.time + timeBetweenAttacks;
                animator.SetTrigger("attack");
            }
        }
    }
    public void RangedAttack() {
        Vector2 direction = player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;

        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }
}
