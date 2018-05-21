using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDeathZone : MonoBehaviour {

     void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObj = GetComponent<Collider2D>().gameObject;

            //Destroy(hitObj);
           // transform.parent.gameObject.AddComponent<GameOverScript>();
        
    }
}
