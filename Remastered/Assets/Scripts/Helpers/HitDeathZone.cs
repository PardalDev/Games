using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDeathZone : MonoBehaviour {

     void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject player = GameObject.Find("Player");
        Destroy(player);

      }
}
