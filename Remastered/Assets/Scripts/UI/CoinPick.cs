using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPick : MonoBehaviour {
    public Transform Explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Pickup", true);
            // Create a new shot
            var coinTransform = Instantiate(Explosion) as Transform;
            // Assign position
            coinTransform.position = transform.position;

            Destroy(collision.gameObject);
        }
    }
}
