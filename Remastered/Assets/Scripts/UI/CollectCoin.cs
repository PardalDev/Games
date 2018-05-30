using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {

    public int cantidad = 1;

    public void OnTriggerEnter(Collider Player)
    {

        Destroy(gameObject);

        if (Player.CompareTag("Player"))
        {
            Player.GetComponent<Controlador>().RecogerObjeto(cantidad);

            
        }

        
    }

    
}
